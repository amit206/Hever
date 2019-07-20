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
        public String FullAddress { get; set; }
        public bool IsAccessible { get; set; }
        public string StoreType { get; set; }
        public string Area { get; set; }
    }
}