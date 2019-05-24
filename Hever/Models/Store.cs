using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Store
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String StreetAndNum { get; set; }
        public bool IsAccessible { get; set; }
        public StoreTypes StoreType { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }
    }
}