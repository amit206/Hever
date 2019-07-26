using Newtonsoft.Json;
using Hever.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fabricio.Controllers
{
    public class StatsController : Controller
    {
        private HeverDbContext db = new HeverDbContext();

        // GET: Stats
        public ActionResult Index()
        {
            var StoresByCity = db.Stores.GroupBy(s => s.Area)
                .Select(i => new { city = i.Key.ToString(), count = i.Count() }).ToList();
            var GroupByCityJson = JsonConvert.SerializeObject(StoresByCity);
            ViewBag.GroupByCityJson = GroupByCityJson;

            var TypeOfLikedRestaurants = db.Restaurants.GroupBy(r=> r.RestaurantType)
                .Select(i => new { type = i.Key.ToString(), count = i.Count() }).ToList();
            var TypeOfLikedRestaurantsJSON = JsonConvert.SerializeObject(TypeOfLikedRestaurants);
            ViewBag.TypeOfLikedRestaurantsJSON = TypeOfLikedRestaurantsJSON;

            return View();
        }
    }
}