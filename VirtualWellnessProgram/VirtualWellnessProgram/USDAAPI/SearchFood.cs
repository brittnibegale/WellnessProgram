using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using VirtualWellnessProgram.Models;

namespace VirtualWellnessProgram.USDAAPI
{
    public static class SearchFood
    {
        public static SearchFoodAPI UsdaCall(string search)
        {
            SearchFoodAPI foodList = new SearchFoodAPI();
            var searchString = search.Trim();
            var wordString = searchString.Split(' ');
            string searchWord = string.Join("_", wordString);
            string url = "https://api.nal.usda.gov/ndb/search/?format=json&q=" + searchWord + "&sort=n&max=25&offset=0&api_key=Bh5vpmhcBF7jU5ejTgdkiYvShURkpVyeF7juFwVL";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "c345954b-9b11-a099-4ca8-c5bfdd7ab140");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);         

            var results = JsonConvert.DeserializeObject<SearchFoodAPI>(response.Content);
            foodList = results;

            return foodList;
        }

        public static FoodInfo GetFood(string id)
        {
            FoodInfo foodItem = new FoodInfo();
            string url = "https://api.nal.usda.gov/ndb/nutrients/?format=json&api_key=Bh5vpmhcBF7jU5ejTgdkiYvShURkpVyeF7juFwVL&nutrients=208&ndbno=" + id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "0820f868-4d88-95fa-9303-7e5334182a77");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            var results = JsonConvert.DeserializeObject<FoodInfo>(response.Content);
            foodItem = results;

            return foodItem;
        }

    }
}