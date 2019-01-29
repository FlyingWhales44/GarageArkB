using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassicGarageArkBar.Models
{
    public class RepairsModels
    {
        public int ID { get; set; }
        public int IdCar { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float RepairPrice { get; set; }
    }
}