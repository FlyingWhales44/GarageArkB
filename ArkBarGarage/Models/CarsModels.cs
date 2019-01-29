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
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int VIN { get; set; }
        public string Series { get; set; }

        [DisplayName("Upload File")]
        public string PhotoURL { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public DateTime PuchaseDate { get; set; }
        public DateTime SaleDate { get; set; }
        public float PuchasePrice { get; set; }
        public float SellingPrice { get; set; }
        public int OwnerId { get; set; }

        public virtual OwnerModels Owner { get; set; }
    }
}