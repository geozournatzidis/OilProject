using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        //public double Price { get; set; }

        //FOREIGN OBJECTS
        //public virtual RawMaterial RawMaterial { get; set; }

        public string Thumbnail { get; set; }

        [DisplayName("Upload File")]
        [NotMapped]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        //FOREIGN KEYS
        //public int RawMaterialID { get; set; }
    }
}
//public enum Category
//{
//    ExtraVirgin = 1,
//    Virgin = 2,
//    OlivePomace = 3
//}