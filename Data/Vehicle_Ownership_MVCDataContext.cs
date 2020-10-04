using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehicle_Ownership_MVC.Models;

namespace Vehicle_Ownership_MVC.Models
{
    //Connects the database and the models.
    public class Vehicle_Ownership_MVCDataContext : DbContext
    {
        public Vehicle_Ownership_MVCDataContext (DbContextOptions<Vehicle_Ownership_MVCDataContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle_Ownership_MVC.Models.Citizen> Citizen { get; set; }

        public DbSet<Vehicle_Ownership_MVC.Models.Vehicle> Vehicle { get; set; }

        public DbSet<Vehicle_Ownership_MVC.Models.OwnerShip> OwnerShip { get; set; }
    }
}
