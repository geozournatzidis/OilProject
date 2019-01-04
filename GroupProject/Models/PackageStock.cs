using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

using GroupProject.DAL;

namespace GroupProject.Models
{
    public class PackageStock
    {
        private OilProjectDbContext db = new OilProjectDbContext();

        public int ID { get; set; }
        public const int MinimumStock = 100;
        public const int MaximumStock = 500;
        // pote xreiazetai na ginei ananewsi paketwn
        public const int ReorderingLevel = 250;
        
        public int Quantity { get; set; }

        // FOREIGN KEYS
        public virtual Package Package { get; set; }
        [Index(IsUnique = true)]
        public int PackageID { get; set; }

        public virtual Sector Sector { get; set; }
        public int SectorID { get; set; }

        public int SendToProduction(int orderAmount, int? id)
        {
            PackageStock packageStock = db.PackageStocks.Find(id);
            if (orderAmount > packageStock.Quantity)
            {
                UpdateStock(id);
                return packageStock.Quantity;
            }
            else
            {
                packageStock.Quantity = packageStock.Quantity - orderAmount;
                //   db.SaveChanges();
                if (packageStock.Quantity <= MinimumStock)
                {
                    UpdateStock(id);
                }
                return packageStock.Quantity;
            }
        }

        public void UpdateStock(int? id)
        {
            PackageStock packageStock = db.PackageStocks.Find(id);
            if (packageStock != null)
            {
                if (packageStock.Quantity <= MinimumStock)
                {
                    int missingStock = MinimumStock - packageStock.Quantity;

                    packageStock.Quantity = OrderFromSupplier(missingStock, id);

                }
            }
        }

        public int OrderFromSupplier(int missingStock, int? id)
        {
            PackageStock packageStock = db.PackageStocks.Find(id);
            int packageNeeded = missingStock + ReorderingLevel + packageStock.Quantity ;

            return packageNeeded;
        }

    }
}