using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SVC { get; set; }
    }
}