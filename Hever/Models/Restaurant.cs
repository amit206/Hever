using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Restaurant name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Full Address")]
        public string FullAddress { get; set; }

        [Display(Name = "Is accessible?")]
        public bool IsAccessible { get; set; }

        [Display(Name = "Is Kosher?")]
        public bool IsKosher { get; set; }

        [Required(ErrorMessage = "Please enter Restaurant type")]
        [Display(Name = "Restaurant Type")]
        public string RestaurantType { get; set; }

        [Required(ErrorMessage = "Please enter area")]
        public string Area { get; set; }
        public virtual ICollection<Users> LikedUsers { get; set; }
    }
}