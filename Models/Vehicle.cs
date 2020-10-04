using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Ownership_MVC.Models
{
    //Vehicle information.
    public class Vehicle
    {
        //Primary key
        public int Id { get; set; }

        //Vehicle Registration number
        public string RegistrationNumber { get; set; }

        //date of register
        [DataType(DataType.Date)]
        public DateTime RegisteredDate{get; set;}

    }
}
