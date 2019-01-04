using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class RawMaterial
    {
        public int ID { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        //Navigation Properties
        public virtual ICollection<Oil> Oils { get; set; } 
        //public virtual ICollection<Supplier> Suppliers { get; set; }

    }
}