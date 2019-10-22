using GraphQl_MyHotel_MyProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_MyHotel_MyProj.EntityFrameworkCore
{
    public class MyHotelDbContext : DbContext
    {
        public MyHotelDbContext(DbContextOptions<MyHotelDbContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Guests
            modelBuilder.Entity<Guest>().HasData(new Guest("Theo Matskas", DateTime.Now.AddDays(-20)) { Id = 1});
            modelBuilder.Entity<Guest>().HasData(new Guest("Ron Todd", DateTime.Now.AddDays(-30)) { Id = 2});
            modelBuilder.Entity<Guest>().HasData(new Guest("Jim Fred", DateTime.Now.AddDays(-15)) { Id = 3});

            // Rooms
            modelBuilder.Entity<Room>().HasData(new Room(101, "yellow-room", RoomStatus.Available, false) { Id = 1 });
            modelBuilder.Entity<Room>().HasData(new Room(102, "blue-room", RoomStatus.Available, false) { Id = 2 });
            modelBuilder.Entity<Room>().HasData(new Room(103, "white-room", RoomStatus.Unavailable, false) { Id = 3 });
            modelBuilder.Entity<Room>().HasData(new Room(104, "black-room", RoomStatus.Unavailable, false) { Id = 4 });

            //Reservations
            modelBuilder.Entity<Reservation>().HasData(new Reservation(3, 1, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3)) { Id = 1 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation(4, 2, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(4)) { Id = 2 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
