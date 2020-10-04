using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Ownership_MVC.Models
{
    // citizen infomation. 
    public class Citizen
    {
        //Primary key
        public int Id { get; set; }

        //Citizen name
        public string Name { get; set; }

        //Citizen address
        public string Address { get; set; }
    }
}
