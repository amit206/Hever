using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hever.Models;
using Newtonsoft.Json;
using System.Net;


namespace Hever.Controllers
{
    public class HomeController : Controller
    {
        private HeverDbContext db = new HeverDbContext();

        // GET: Home
        public ActionResult Index(int? id)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser != null)
            {
                int numOfRecords = 5;

                if (id != null)
                {
                    // Restaurants
                    // Get all the rest that current user likes
                    IEnumerable<int> likedRes = db.Users.Where(u => u.Id == id).Select(p => p.LikedRestaurants.Select(res => res.Id)).SingleOrDefault().ToList();

                    // Get all users that like at least one restaurant in common with current user
                    IEnumerable<int> usersRes = db.Users.Where(u => u.LikedRestaurants.Select(res => res.Id).Any(rst => likedRes.Contains(rst))
                                             && u.Id != id).Select(uid => uid.Id).ToList();

                    // Get all the restaurants that they like but current user didn't
                    var recommRes = db.Restaurants.Where(rst => rst.LikedUsers.Any(l => usersRes.Contains(l.Id))
                                    && !rst.LikedUsers.Select(rid => rid.Id).Contains((int)id)).Take(numOfRecords).ToList();

                    if(recommRes.Count() == 0)
                    {
                        recommRes = db.Restaurants.OrderBy(res => likedRes.Count()).Take(1).ToList();
                    }

                    // Stores
                    // Get all the stores that current user likes
                    IEnumerable<int> likedStore = db.Users.Where(u => u.Id == id).Select(p => p.LikedStores.Select(res => res.Id)).SingleOrDefault().ToList();

                    // Get all users that like at least one store in common with current user
                    IEnumerable<int> usersStore = db.Users.Where(u => u.LikedStores.Select(str => str.Id).Any(sto => likedStore.Contains(sto))
                                             && u.Id != id).Select(uid => uid.Id).ToList();

                    // Get all the stores that they like but current user didn't
                    var recommStores = db.Stores.Where(str => str.LikedUsers.Any(l => usersStore.Contains(l.Id))
                                    && !str.LikedUsers.Select(stid => stid.Id).Contains((int)id)).Take(numOfRecords).ToList();

                    if (recommStores.Count() == 0)
                    {
                        recommStores = db.Stores.OrderBy(res => likedStore.Count()).Take(1).ToList();
                    }

                    ViewBag.recommendedRestaurants = recommRes;
                    ViewBag.recommendedStores = recommStores;
                }
            }
            return View();
        }

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}