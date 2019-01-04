using GroupProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models
{
    public class Shop
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        [Key]
        public int ShopID { get; set; }

        [Required]
        [Display(Name = "Shop Name")]
        [StringLength(25, ErrorMessage = "'Shop Name' must be between 1-25 chars", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "'Country' must be between 1-25 chars", MinimumLength = 1)]
        public string Country { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "'City' must be between 1-25 chars", MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "'Address' must be between 1-50 chars", MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int ShopStockMin = 50;
        public int ShopStockMax = 350;
        public int ShopStockAvailable { get; set; }
        public int ExpiredProduct { get; set; }
        public int SoldProduct { get; set; }

        // Foreign Keys
        public int ProductStockID { get; set; }
        public int DepartmentID { get; set; }

        // Navigation Properties

        //From Employees 
        //public virtual ProductStock ProductStock { get; set; }
        //public virtual Department Department { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Product> Products { get; set; }


        //// Create shop method
        //// [HttpPost]
        //// [ValidateAntiForgeryToken]
        //public Shop CreateShop(Shop shop)
        //{
        //    try
        //    {
        //        db.Shops.Add(shop);
        //        db.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        // (DataException)
        //        // ModelState.AddModelError("", "Unable to save changes. Try again later.");

        //        Console.WriteLine(e.Message);
        //    }

        //    return shop;
        //}

        //// Delete shop method
        //public void DeleteShop(Shop shop)
        //{
        //    try
        //    {
        //        db.Entry(shop).State = EntityState.Deleted;
        //        db.SaveChanges();
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //// Get products from warehouse
        //public int GetProduct(int? id, int productQuantity)
        //{
        //    Shop shop = db.Shops.Find(id);

        //    if (shop.ShopStockAvailable <= ShopStockMin)
        //    {
        //        shop.ShopStockAvailable = shop.ShopStockAvailable + productQuantity;
        //    }

        //    return productQuantity;
        //}



        //// Sold products
        //public int SaleOfProduct(int? id, int soldProducts)
        //{
        //    Shop shop = db.Shops.Find(id);

        //    shop.SoldProduct = soldProducts;
        //    shop.ShopStockAvailable = ShopStockAvailable - shop.SoldProduct;

        //    return soldProducts;
        //}

    }

}