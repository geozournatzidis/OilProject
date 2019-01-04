using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class Warehouse
    {
        public int ID { get; set; }
        public string Address { get; set; }
        //public List<Product> ProductSection { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
        
    }
}