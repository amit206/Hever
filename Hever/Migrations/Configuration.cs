using Hever.Models;

namespace Hever.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hever.Models.HeverDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Hever.Models.HeverDbContext";
       }

        protected override void Seed(Hever.Models.HeverDbContext context)
        {
            var dataRestaurants = (from n in context.Restaurants select n);
            context.Restaurants.RemoveRange(dataRestaurants);
            var dataStores = (from n in context.Stores select n);
            context.Stores.RemoveRange(dataStores);
            var dataUsers = (from n in context.Users select n);
            context.Users.RemoveRange(dataUsers);

            context.Users.Add(new Users() {Id=1, UserName = "Einor", Password="Einor", IsAdmin = true });
            context.Users.Add(new Users() {Id=2, UserName = "Amit", Password= "Amit", IsAdmin = true });
            context.Users.Add(new Users() {Id=3, UserName = "1", Password="1", IsAdmin = true });
            context.Users.Add(new Users() {Id=4, UserName = "2", Password="2", IsAdmin = false });
            context.Users.Add(new Users() {Id=5, UserName = "3", Password="3", IsAdmin = false });

            context.Stores.Add(new Store() { Id = 1, Name = "YOLO", FullAddress = "Yizchak Rabin 53 Ramat Gan", IsAccessible = true, StoreType = "Books", Area = "Center" });
            context.Stores.Add(new Store() { Id = 2, Name = "YOLO", FullAddress = "Atir Yeda 4 Kfar Saba", IsAccessible = false, StoreType = "Books", Area = "Sharon" });
            context.Stores.Add(new Store() { Id = 3, Name = "Fox", FullAddress = "Ha'agas 1 Rosh Pina", IsAccessible = true, StoreType = "Clothes", Area = "Notrh" });
            context.Stores.Add(new Store() { Id = 4, Name = "Fox", FullAddress = "Yixchak Rabin 18 Afula", IsAccessible = true, StoreType = "Clothes", Area = "Notrh" });
            context.Stores.Add(new Store() { Id = 5, Name = "Fox", FullAddress = "Hapalmach 1 Eilat", IsAccessible = true, StoreType = "Clothes", Area = "Eilat" });
            context.Stores.Add(new Store() { Id = 6, Name = "Fox", FullAddress = "Derech hevron 21 Be'er Sheva", IsAccessible = true, StoreType = "Clothes", Area = "South" });
            context.Stores.Add(new Store() { Id = 7, Name = "Fox", FullAddress = "Golda Meir 7 Holon", IsAccessible = true, StoreType = "Clothes", Area = "Center" });
            context.Stores.Add(new Store() { Id = 8, Name = "Adidas", FullAddress = "David Sacharov 21 Rishon Leziyon", IsAccessible = true, StoreType = "Sport", Area = "Center" });
            context.Stores.Add(new Store() { Id = 9, Name = "Adidas", FullAddress = "Hamelacha 2 Ra'anana", IsAccessible = true, StoreType = "Sport", Area = "Sharon" });
            context.Stores.Add(new Store() { Id = 10, Name = "Adidas", FullAddress = "Yitzchak Kriv 6 Jerusalem", IsAccessible = true, StoreType = "Sport", Area = "Jerusalem" });
            context.Stores.Add(new Store() { Id = 11, Name = "Opticana", FullAddress = "Moshe Fliman 4 Haifa", IsAccessible = true, StoreType = "Glasses", Area = "Notrh" });
            context.Stores.Add(new Store() { Id = 12, Name = "Opticana", FullAddress = "Bnei Barmen 2 Natania", IsAccessible = true, StoreType = "Glasses", Area = "Sharon" });
            context.Stores.Add(new Store() { Id = 13, Name = "Opticana", FullAddress = "Shderot David Ben Gurion 21 Ashkelon", IsAccessible = true, StoreType = "Glasses", Area = "South" });
            context.Stores.Add(new Store() { Id = 14, Name = "Opticana", FullAddress = "Sderot Hatmarim 1 Eilat", IsAccessible = false, StoreType = "Glasses", Area = "Eilat" });
            context.Stores.Add(new Store() { Id = 15, Name = "TOP SHOP", FullAddress = "Einshtin 40 Tel Aviv", IsAccessible = true, StoreType = "Clothes", Area = "Center" });
            context.Stores.Add(new Store() { Id = 16, Name = "TOP SHOP", FullAddress = "Yaldei Teheran 5 Rishon Lezyon", IsAccessible = true, StoreType = "Clothes", Area = "Center" });
            context.Stores.Add(new Store() { Id = 17, Name = "TOP SHOP", FullAddress = "Herzel 5, Kiriat Ekron", IsAccessible = true, StoreType = "Clothes", Area = "Center" });
            context.Stores.Add(new Store() { Id = 18, Name = "TOP SHOP", FullAddress = "Herkon 2 Hod Hasharon", IsAccessible = true, StoreType = "Clothes", Area = "Sharon" });
            context.Stores.Add(new Store() { Id = 19, Name = "FIX", FullAddress = "King George 2, Jerusalem", IsAccessible = true, StoreType = "Clothes", Area = "Jerusalem" });
            context.Stores.Add(new Store() { Id = 20, Name = "FIX", FullAddress = "Sokolove 90 Ramat Hasharon", IsAccessible = true, StoreType = "Clothes", Area = "Sharon" });
            context.Stores.Add(new Store() { Id = 21, Name = "FIX", FullAddress = "Hayarkon 75 Tel Aviv", IsAccessible = true, StoreType = "Clothes", Area = "Center" });
            context.Stores.Add(new Store() { Id = 22, Name = "Sabon", FullAddress = "Hanasi Vizman 1 Haifa", IsAccessible = true, StoreType = "Beauty", Area = "Notrh" });
            context.Stores.Add(new Store() { Id = 23, Name = "Sabon", FullAddress = "David Tubihao 125 Be'er sheva", IsAccessible = true, StoreType = "Beauty", Area = "South" });
            context.Stores.Add(new Store() { Id = 24, Name = "Sabon", FullAddress = "Ze'ev Jabotinski 72 Petach Tikva", IsAccessible = true, StoreType = "Beauty", Area = "Sharon" });
            context.Stores.Add(new Store() { Id = 25, Name = "Sabon", FullAddress = "Hashonit 2 Herzelia", IsAccessible = true, StoreType = "Beauty", Area = "Sharon" });
            context.Stores.Add(new Store() { Id = 26, Name = "Sabon", FullAddress = "Vitman 14 Tel Aviv", IsAccessible = true, StoreType = "Beauty", Area = "Center" });
            context.Stores.Add(new Store() { Id = 27, Name = "Gali", FullAddress = "Disingof 65 Tel Aviv", IsAccessible = false, StoreType = "Shoes", Area = "Center" });
            context.Stores.Add(new Store() { Id = 28, Name = "Gali", FullAddress = "Jabotinski 39 Ashdod", IsAccessible = true, StoreType = "Shoes", Area = "South" });
            context.Stores.Add(new Store() { Id = 29, Name = "Gali", FullAddress = "Derech Hevron 21 Be'er Sheva", IsAccessible = true, StoreType = "Shoes", Area = "South" });
            context.Stores.Add(new Store() { Id = 30, Name = "Gali", FullAddress = "Derech Sheshet Hayamim 16 Ramat Gan", IsAccessible = true, StoreType = "Shoes", Area = "Center" });

            context.Restaurants.Add(new Restaurant() { Id = 1, Name = "DEDA", FullAddress = "Ben Gurion 61 Bat Yam", IsAccessible = true, IsKosher = false, RestaurantType = "Other", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 2, Name = "Madam", FullAddress = "Menachem Begin 29 Givat Shmoel", IsAccessible = true, IsKosher = true, RestaurantType = "Other", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 3, Name = "Tito Italiano", FullAddress = "Yitzack Rabin 53 Givataym", IsAccessible = true, IsKosher = false, RestaurantType = "Italian", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 4, Name = "Inga", FullAddress = "Glilay Haplada", IsAccessible = true, IsKosher = false, RestaurantType = "Other", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 5, Name = "Bistro 45", FullAddress = "Kogel 45 Holon", IsAccessible = true, IsKosher = true, RestaurantType = "Bar", Area = "Sharon" });
            context.Restaurants.Add(new Restaurant() { Id = 6, Name = "Hasoshia", FullAddress = "Yael Rom 8 Petech Tikva", IsAccessible = true, IsKosher = false, RestaurantType = "Other", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 7, Name = "Black", FullAddress = "Hasivim 18 Petech Tikva", IsAccessible = false, IsKosher = false, RestaurantType = "Meat", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 8, Name = "Kan Kai", FullAddress = "Moshe Dayan 2 Rosh Hahain", IsAccessible = true, IsKosher = true, RestaurantType = "Chainees", Area = "Sharon" });
            context.Restaurants.Add(new Restaurant() { Id = 9, Name = "Retro", FullAddress = "Mazal Eliezer 11 Rishon Lezyon", IsAccessible = true, IsKosher = false, RestaurantType = "Sweets", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 10, Name = "Greg", FullAddress = "Yaldey Teheran 3 Rishon Lezyon", IsAccessible = true, IsKosher = false, RestaurantType = "CoffeePlace", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 11, Name = "Chanpions", FullAddress = "Peretz Bareshtain 7 Ramat Gan", IsAccessible = true, IsKosher = true, RestaurantType = "Other", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 12, Name = "Just Meat", FullAddress = "Derech Shlomo 19 Tel Aviv", IsAccessible = true, IsKosher = false, RestaurantType = "Meat", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 13, Name = "Max Brener", FullAddress = "habarzel 33 Tel Aviv", IsAccessible = true, IsKosher = false, RestaurantType = "Sweets", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 14, Name = "BROWN", FullAddress = "Nisim Aloni 1o Tel Aviv", IsAccessible = true, IsKosher = false, RestaurantType = "CoffeePlace", Area = "Center" });
            context.Restaurants.Add(new Restaurant() { Id = 15, Name = "Nily", FullAddress = "Hameyasdim 42 Zichron Ya'akov", IsAccessible = true, IsKosher = true, RestaurantType = "CoffeePlace", Area = "Notrh" });
            context.Restaurants.Add(new Restaurant() { Id = 16, Name = "Petricks", FullAddress = "Hanasi 134 Haifa", IsAccessible = true, IsKosher = false, RestaurantType = "Bar", Area = "Notrh" });
            context.Restaurants.Add(new Restaurant() { Id = 17, Name = "Pasta Loca", FullAddress = "Helel Yafee 21 Hadera", IsAccessible = true, IsKosher = false, RestaurantType = "Italian", Area = "Notrh" });
            context.Restaurants.Add(new Restaurant() { Id = 18, Name = "Siesta", FullAddress = "Chel Hahandasa 5 Be'er Sheva", IsAccessible = true, IsKosher = false, RestaurantType = "CoffeePlace", Area = "South" });
            context.Restaurants.Add(new Restaurant() { Id = 19, Name = "Rockfor", FullAddress = "Hapoalym 5 Dimona", IsAccessible = true, IsKosher = true, RestaurantType = "Other", Area = "South" });
       }
   }
}
