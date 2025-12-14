using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PortfolioWebApplication.Models.Maps
{
    public class tbl_messagesMap : EntityTypeConfiguration<tbl_messagesModel>
    {
        public tbl_messagesMap() {
            HasKey(i => i.messageId);
            ToTable("tbl_messages");
        }
    }
}