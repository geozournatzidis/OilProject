using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GroupProject.Models;

namespace GroupProject.DAL
{
    public class GroupProjectInitializer : DropCreateDatabaseIfModelChanges<OilProjectDbContext>
    {
        protected override void Seed(OilProjectDbContext context)
        {
            var factories = new List<Factory>
            {
                new Factory
                {

                }
            };


            factories.ForEach(s => context.Factories.Add(s));
            context.SaveChanges();
        }
    }
}