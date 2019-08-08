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
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Error");
            }


            /*var StoresAndResByArea = 
                db.Stores.GroupBy(s => s.Area)
                .Select(i => new { city = i.Key.ToString(), count = i.Count() })

                .Union(db.Restaurants.GroupBy(s => s.Area)
                .Select(i => new { city = i.Key.ToString() , count = i.Count() }))

                .GroupBy(s => s.city)
                .Select(i => new { city = i.Key, count = i.Sum(s => s.count) })
                .ToList();*/
            var StoresAndResByArea =
                db.Stores.Select(s => new { city = s.Area })
                .Concat(db.Restaurants.Select(r => new { city = r.Area }))
                .GroupBy(s => s.city)
                .Select(i => new { city = i.Key, count = i.Count() })
                .ToList();
            var GroupByStoresAndResJson = JsonConvert.SerializeObject(StoresAndResByArea);
            ViewBag.GroupByAreaJson = GroupByStoresAndResJson;

            var TypeOfLikedRestaurants = db.Restaurants.Where(r => r.LikedUsers.Count() != 0)
                .Select(i => new { type = i.RestaurantType, count = i.LikedUsers.Count() })
                .GroupBy(r => r.type)
                .Select(i => new { type = i.Key.ToString(), count = i.Sum(s => s.count) })
                .ToList();
            var TypeOfLikedRestaurantsJSON = JsonConvert.SerializeObject(TypeOfLikedRestaurants);
            ViewBag.TypeOfLikedRestaurantsJSON = TypeOfLikedRestaurantsJSON;

            return View();
        }
    }
}