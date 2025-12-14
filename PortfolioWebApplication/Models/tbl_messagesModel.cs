using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioWebApplication.Models
{
    public class tbl_messagesModel
    {
        public int messageId { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string subject { get; set; }

        public string message { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updateAt { get; set; }
        public int isArchived
        {
            get; set;
        }
    }
}