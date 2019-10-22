using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_MyHotel_MyProj.Entities
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }

        public Guest()
        {

        }

        public Guest(string name, DateTime registerDate)
        {
            Name = name;
            RegisterDate = registerDate;
        }
    }

    public class GuestModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
