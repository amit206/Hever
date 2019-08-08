﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hever.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Restaurant> LikedRestaurants { get; set; }
        public virtual ICollection<Store> LikedStores { get; set; }
    }
}