using Newtonsoft.Json;
using Hever.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hever.Controllers
{
    public class StatsController : Controller
    {
        private HeverDbContext db = new HeverDbContext();

        // GET: Stats
        public ActionResult Index()
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return RedirectToAction("Index", "Error");
            }

            
            var StoresAndResByArea = 
                db.Stores.GroupBy(s => s.Area)
                .Select(i => new { city = i.Key.ToString(), count = i.Count() })

                .Union(db.Restaurants.GroupBy(s => s.Area)
                .Select(i => new { city = i.Key.ToString() , count = i.Count() }))

                .GroupBy(s => s.city)
                .Select(i => new { city = i.Key, count = i.Sum(s => s.count) })
                .ToList();
            var GroupByStoresAndResJson = JsonConvert.SerializeObject(StoresAndResByArea);
            ViewBag.GroupByAreaJson = GroupByStoresAndResJson;

            var TypeOfLikedRestaurants = db.Restaurants.Where(u => u.LikedUsers.Count() != 0)
                .GroupBy(r=> r.RestaurantType)
                
                .Select(i => new { type = i.Key.ToString(), count = i.Count() }).ToList();
            var TypeOfLikedRestaurantsJSON = JsonConvert.SerializeObject(TypeOfLikedRestaurants);
            ViewBag.TypeOfLikedRestaurantsJSON = TypeOfLikedRestaurantsJSON;

            return View();
        }
    }
}