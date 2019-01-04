using GroupProject.DAL;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web; 



namespace GroupProject.Models
{
    public class RawMaterialStock
    {
        private OilProjectDbContext db = new OilProjectDbContext();

        public int ID { get; set; }
        public const int MinimumStock = 1000;
        public const int MaximumStock = 5000;

        public const int ReorderingLevel = 2500;

        [Display (Name = "Available Quantity")]
        public int Quantity { get; set; }

        // FOREIGN KEYS
        public virtual RawMaterial RawMaterial { get; set; }
        [Index(IsUnique = true)]
        public int RawMaterialID { get; set; }                
                                                    
        public virtual Sector Sector { get; set; }                
        public int SectorID { get; set; }

        public virtual ICollection<OilPress> OilPresses { get; set; } //For the One to many relationship with the RawMaterialStock 

        public int SendToProduction(int orderAmount, int? id)                     
        {
            RawMaterialStock rawMaterialStock = db.RawMaterialStocks.Find(id);               
            if (orderAmount > rawMaterialStock.Quantity)                 
            {
                int sentQuantity = rawMaterialStock.Quantity;                      
                UpdateStock(id);
                return sentQuantity;
            }
            else
            {
                rawMaterialStock.Quantity = rawMaterialStock.Quantity - orderAmount;
                if (rawMaterialStock.Quantity <= MinimumStock)
                {
                    UpdateStock(id);
                }
                return rawMaterialStock.Quantity;
            }
        }

        public void UpdateStock(int? id)
        {
            RawMaterialStock rawMaterialStock = db.RawMaterialStocks.Find(id);
            if (rawMaterialStock != null)
            {
                if (rawMaterialStock.Quantity <= MinimumStock)
                {
                    int missingStock = MinimumStock - rawMaterialStock.Quantity;

                    rawMaterialStock.Quantity = OrderFromSupplier(missingStock, id);

                }
            }
        }

        public int OrderFromSupplier(int missingStock, int? id)
        {
            RawMaterialStock rawMaterialStock = db.RawMaterialStocks.Find(id);

            int rawMaterialNeeded = missingStock + ReorderingLevel + rawMaterialStock.Quantity;

            return rawMaterialNeeded ;
        }
    }
}