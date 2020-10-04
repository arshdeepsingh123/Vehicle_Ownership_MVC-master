using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Ownership_MVC.Models
{
    //Ownership information.
    public class OwnerShip
    {
        //Ownership id
        public int Id { get; set; }

        //Vehicle id 
        public int VehicleId { get; set; }
        //Citizen id
        public int CitizenId { get; set; }

        //Citizen relationship
        public Citizen Citizen { get; set; }

        //Vehicle relationship
        public Vehicle  Vehicle { get; set; }
    }
}
