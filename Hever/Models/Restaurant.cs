using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAndNum { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsKosher { get; set; }
        public RestaurantTypes RestaurantType { get; set; }
        public string FacebookLink { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }
    }
}