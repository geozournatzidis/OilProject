using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace GroupProject.Models
{
    public class Product
    {
        public int ID { get; set; }

        public bool Featured { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; } //tha parei apo to production date ara den paei sth vash

        [NotMapped]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Upload File")]
        public string Thumbnail { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        public string BarCode { get; set; }


        //[Index(IsUnique = true)] ean empaine sth vash
        [NotMapped]
        private string productNumber { get; set; }
        public string ProductNumber
        {
            get { return productNumber; }
            set
            {
                //productNumber = Package.Material.ToString() + Package.Size.ToString() + Oil.Category.Description.ToString();
            }
        }

        //Navigation Properties
        [Display(Name = "Package")]
        public virtual Package Package { get; set; }

        [Display(Name = "Oil")]
        public virtual Oil Oil { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }

        //Ta ID tous

        [Display(Name = "Package")]
        public int? PackageID { get; set; }

        [Display(Name = "Oil")]
        [Required]
        public int OilID { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }

    }
}