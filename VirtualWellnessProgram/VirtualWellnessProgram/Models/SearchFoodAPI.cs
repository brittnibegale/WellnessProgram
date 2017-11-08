using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json;

namespace VirtualWellnessProgram.Models
{
        public class SearchFoodAPI
        {
            [JsonProperty("list")]
            public List List { get; set; }
        }

        public class List
        {
            [JsonProperty("ds")]
            public string Ds { get; set; }

            [JsonProperty("end")]
            public long End { get; set; }

            [JsonProperty("group")]
            public string Group { get; set; }

            [JsonProperty("item")]
            public Item[] Item { get; set; }

            [JsonProperty("q")]
            public string Q { get; set; }

            [JsonProperty("sort")]
            public string Sort { get; set; }

            [JsonProperty("sr")]
            public string Sr { get; set; }

            [JsonProperty("start")]
            public long Start { get; set; }

            [JsonProperty("total")]
            public long Total { get; set; }
        }

        public class Item
        {
            [JsonProperty("ds")]
            public string Ds { get; set; }

            [JsonProperty("group")]
            public string Group { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("ndbno")]
            public string Ndbno { get; set; }

            [JsonProperty("offset")]
            public long Offset { get; set; }
        }
    }

