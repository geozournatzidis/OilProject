using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupProject.Models;

namespace GroupProject.ViewModels
{
    public class ProducersData
    {
        public IEnumerable<UsersAccount> UsersAccounts;
        public IEnumerable<OilPress> OilPresses;
        public IEnumerable<Factory> Factories;
        public IEnumerable<RawMaterialStock> RawMaterialStocks;

        



        //public int FactoryID { get; set; }
        //public string FactoryName { get; set; }

    }
}