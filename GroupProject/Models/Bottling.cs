using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class Bottling
    {
        public int BottlingID { get; set; }
        public DateTime BottlingDate { get; set; }
        public string ProductCode { get; set; }
        public int BottlingLotNumber { get; set; }
        public Package PackageType { get; set; }
        public Product ProductType { get; set; }
        public Tanks tank {get; set;}
        public double Quantity { get; set; }


        public int? FactoryID { get; set; }
        public virtual Factory Factory { get; set; }

        //public Factory Factory { get; set; }
        //public ICollection<Factory> Factories { get; set; }

    }
}