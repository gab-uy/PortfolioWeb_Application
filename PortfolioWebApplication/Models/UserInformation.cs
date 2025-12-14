using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioWebApplication.Models
{
    public class UserInformation
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string subject { get; set; }
        public string message { get; set; } // Added this to capture the message from the form
    }
}