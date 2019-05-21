using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        public  String StoreName { get; set; }

        public int Address{ get; set; }

        public bool IsAccessible { get; set; }

        public int MyProperty { get; set; }
    }
}