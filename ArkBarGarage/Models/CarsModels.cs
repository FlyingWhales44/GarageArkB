using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClassicGarageArkBar.Models
{
    public class CarsModels
    {
        public int ID { get; set; }
        public int IdCar { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string YearOfProduction { get; set; }
        public string VIN { get; set; }
        public string Series { get; set; }
        public string Phonenumber { get; set; }
        public string PhotoURL { get; set; }
        public string Description { get; set; }
        public float SellingPrice { get; set; }

    }
}