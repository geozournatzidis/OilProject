using GroupProject.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace GroupProject.Models
{
    public class Sector
    {
        private OilProjectDbContext db = new OilProjectDbContext();

        public int ID { get; set; }

        [Display(Name = "Sector Name")]
        public string Name { get; set; }

        [Display(Name = "Stored Type")]
        public string StoredType { get; set; }

        //[NotMapped]
        //public int PackageStockTotal
        //{
        //    get
        //    {
        //        return db.PackageStock.Include(p => p.Sector).Where(p => p.Sector.ID == ID).Count();
        //    }
        //}

        //[NotMapped]
        //public int ProductStockTotal
        //{
        //    get
        //    {
        //        return db.ProductStock.Include(p => p.Sector).Where(p => p.Sector.ID == ID).Count();
        //    }
        //}

        // FOREIGN KEYS
        public int WarehouseID { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}