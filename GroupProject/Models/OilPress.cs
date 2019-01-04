using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{

    //Central Table !! 
    public enum Tanks
    {
        A = 1, B = 2, C = 3, D = 4

    }

    public class OilPress
    {
        
        public int OilPressID{ get; set; }

        public string OilPressName { get; set; }
        //public string ProducerName { get; set; }
        public string OliveType { get; set; }
        public double OlivesWeight { get; set; }
        public double OilOutput { get; set; }
        //public double OliveWastes { get; set; }
        public DateTime ProductionDate { get; set; }



        public int? FactoryID { get; set; } // Use of this two properties to show the DropdownLists of Factory and Producers at the Productions Create 
        public int? UserId { get; set; }
        public int Quantity { get; set; } // In order to show the DropDownList of the Quantity 

        //Navigation Properties 

        public virtual Factory Factory {get;set;}
        public virtual UsersAccount UsersAccount { get; set; }
        public virtual RawMaterialStock RawMaterialStock { get; set; } //For the One to many relationship with the RawMaterialStock

        //public OilPress(string producerName, double oliveInput, DateTime productionDate)
        //{
        //    ProducerName = producerName;
        //    OliveInput = oliveInput;
        //    ProductionDate = productionDate;
        //}


        public double ToOilPercent(double input, double output)
        {
            if (!double.TryParse(Console.ReadLine(), out input))
            {
                ToOilPercent(input, output);
            }

            if (!double.TryParse(Console.ReadLine(), out output))
            {
                ToOilPercent(input, output);
            }

            double olivePercent = (output / input) * 100;
            return olivePercent;
        }

    }
}