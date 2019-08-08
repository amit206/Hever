using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter store name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Full Address")]
        public String FullAddress { get; set; }

        [Display(Name = "Is Accessible?")]
        public bool IsAccessible { get; set; }

        [Required(ErrorMessage = "Please enter store type")]
        [Display(Name = "Store Type")]
        public string StoreType { get; set; }

        [Required(ErrorMessage = "Please enter area")]
        public string Area { get; set; }
        public virtual ICollection<Users> LikedUsers { get; set; }
    }
}