using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class Lot
    {
        public int ID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Production Date")]
        [DataType(DataType.DateTime)]
        public DateTime ProductionDate { get; set; }

        public int Quantity { get; set; } // posa evgale to lot
        public virtual Product Product { get; set; }

        [Display(Name = "Product")]
        public int? ProductID { get; set; }
    }
}