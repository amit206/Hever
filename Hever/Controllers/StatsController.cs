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

           // IEnumerable<int> likedStore = db.Users.Where(u => u.Id == id).Select(p => p.LikedStores.Select(res => res.Id)).SingleOrDefault().ToList();

            // Get all users that likes at least one store in common
            //IEnumerable<int> usersStore = db.Users.Where(u => u.LikedStores.Select(str => str.Id).Any(sto => likedStore.Contains(sto))
           //                          && u.Id != id).Select(uid => uid.Id).ToList();

            // Get all the stores that they like but current user didn't
           // var recommStores = db.Stores.Where(str => str.LikedUsers.Any(l => usersStore.Contains(l.Id))
           //                 && !str.LikedUsers.Select(stid => stid.Id).Contains((int)id)).Take(numOfRecords).ToList();

        }
    }
}