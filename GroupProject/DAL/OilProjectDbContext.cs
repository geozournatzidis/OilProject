using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GroupProject.DAL
{
    public class OilProjectDbContext : DbContext
    {
        public OilProjectDbContext() : base("OilProjectContext")
        { }

        public DbSet<Factory> Factories { get; set; }
        public DbSet<OilPress> OilPresses { get; set; }
        public DbSet<Bottling> Bottlings { get; set; }
        public DbSet<Package> Packages { get; set; }
        //public DbSet<Producer> Producers { get; set; }
        public DbSet<UsersAccount> UsersAccounts { get; set; }
        public DbSet<PackageStock> PackageStocks { get; set; }
        public DbSet<RawMaterialStock> RawMaterialStocks { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public System.Data.Entity.DbSet<ShopProject.Models.Shop> Shops { get; set; }
    }
}