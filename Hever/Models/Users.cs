using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public bool IsAdmine { get; set; }
        public int CardNumber { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public int Cvs { get; set; }
        public ICollection<Restaurant> LikedRestaurants { get; set; }
    }
}