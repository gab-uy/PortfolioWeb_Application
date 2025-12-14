using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PortfolioWebApplication.Models.Maps;



namespace PortfolioWebApplication.Models.Context
{
    public class ITDContext : DbContext
    {
        static ITDContext() {
            Database.SetInitializer<ITDContext>(null); 
        }

            public ITDContext() : base("portfoliowebapp_db") { }
            public virtual DbSet<tbl_messagesModel> tbl_messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new tbl_messagesMap());

                }
       
    }

}