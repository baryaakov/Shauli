using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models
{
    public class Fan
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Enums.Gender Gender { get; set; }

        public DateTime Birthday { get; set; }

        public int Seniority { get; set; }


        public Fan()
        {

        }
    }


    public class FanDbContext : DbContext
    {
        public DbSet<Fan> Fans { get; set; }
    }
}