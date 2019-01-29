using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassicGarageArkBar.Models
{
    public class PartsModels
    {
        public int ID { get; set; }
        public int IdCar { get; set; }
        public string Name { get; set; }
        public string CatalogNr { get; set; }
        public float PurchasePrice { get; set; }
        public float SellingPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime SellingDate { get; set; }
    }
}