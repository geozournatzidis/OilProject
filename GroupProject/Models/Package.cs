#region
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace WebOil.Models
//{

//    public class Package
//    {
//        public int ID { get; set; }
//        //public double Volume { get; set; }
//        public PackageMaterial PackageMaterial { get; set; }
//        public Size Size { get; set; }

//        [DataType(DataType.Currency)]
//        public double Price { get; set; }

//        [Display(Name = "Size")]
//        public int SizeID { get; set; }

//        [Display(Name = "Material")]
//        public int PackageMaterialID { get; set; }
//        //public virtual Supplier Supplier { get; set; }

//        //public int SupplierID { get; set; }
//    }
//}
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using GroupProject.DAL;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models
{
    public enum Size
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }

    public enum MaterialType
    {
        Glass = 1,
        Plastic = 2
    }

    public class Package
    {
        public int ID { get; set; }
        public string Name { get; set; }


        [NotMapped]
        public double Volume
        {
            get
            {
                if (Size == Size.Small)
                    return 20;
                else if (Size == Size.Medium)
                    return 60;
                else
                    return 100;
            }
        }

        //[NotMapped]
        //public double Volume { get; set; }

        public MaterialType Material { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }

        public double Height { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        //public Package()
        //{
        //    if (Size == Size.Small)
        //        Volume = 20;
        //    else if (Size == Size.Medium)
        //        Volume = 60;
        //    else
        //        Volume = 100;
        //}

        public Package()
        { }

        public static void CreatePackageType(Package package)
        {
            OilProjectDbContext db = new OilProjectDbContext();

            //var package = new Package
            //{
            //    Name = name,
            //    Height = height,
            //    Length = length,
            //    Width = width,
            //    Material = materialType,
            //    Price = price,
            //    Size = size
            //};

            db.Packages.Add(package);
            db.SaveChanges();
        }

        public static void EditPackageType(Package package)
        {
            OilProjectDbContext db = new OilProjectDbContext();

            //var packageToUpdate = db.Packages.Find(package.ID);
            db.Entry(package).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeletePackageType(int packageID)
        {
            OilProjectDbContext db = new OilProjectDbContext();

            Package package = db.Packages.Find(packageID);
            db.Packages.Remove(package);
            db.SaveChanges();
        }
    }

}