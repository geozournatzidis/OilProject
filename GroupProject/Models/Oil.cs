using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class Oil
    {
        public int ID { get; set; }

        [Display(Name = "Oil Category")]
        public virtual Category Category{ get; set; }

        //Navigation Properties
        [Display(Name = "Raw Material")]
        public virtual RawMaterial RawMaterial { get; set; }


        public virtual ICollection<Product> Products { get; set; }

        [Display(Name = "Raw Material")]
        public int RawMaterialID { get; set; }

        [Display(Name = "Oil Category")]
        public int OilCategoryID { get; set; }
    }
}
