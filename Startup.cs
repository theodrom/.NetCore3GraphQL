using AutoMapper;
using GraphQl_MyHotel_MyProj.Entities;
using GraphQl_MyHotel_MyProj.EntityFrameworkCore;
using GraphQl_MyHotel_MyProj.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using GraphQl_MyHotel_MyProj.Mapper;
using GraphQl_MyHotel_MyProj.GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace GraphQl_MyHotel_MyProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string con = Configuration.GetConnectionString("DefaultConnection");

            services.AddControllersWithViews();

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddDbContext<MyHotelDbContext>(options => options.UseSqlServer(con));
            services.AddTransient<ReservationRepository>();



            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ReservationsMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            // < GraphQL >
            services.AddSingleton<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));

            services.AddScoped<MyHotelSchema>();
            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true; //set true only in development mode. make it switchable.
            })
            .AddGraphTypes(ServiceLifetime.Scoped)
            .AddDataLoader();
            // </ GraphQL >




            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyHotelDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGraphQL<MyHotelSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); 
            //to explorer API navigate https://*DOMAIN*/ui/playground


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            InitializeMapper();
        }

        private void InitializeMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Guest, GuestModel>();
                x.CreateMap<Room, RoomModel>();
                x.CreateMap<Reservation, ReservationModel>();
            });
        }
    }
}
