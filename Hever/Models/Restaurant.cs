using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsKosher { get; set; }
        public RestaurantTypes RestaurantType { get; set; }
    }
}