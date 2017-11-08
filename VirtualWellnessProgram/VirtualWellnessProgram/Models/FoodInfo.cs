using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace VirtualWellnessProgram.Models
{
        public class FoodInfo
        {
            [JsonProperty("report")]
            public Report Report { get; set; }
        }

        public class Report
        {
            [JsonProperty("end")]
            public long End { get; set; }

            [JsonProperty("foods")]
            public Food[] Foods { get; set; }

            [JsonProperty("groups")]
            public string Groups { get; set; }

            [JsonProperty("sr")]
            public string Sr { get; set; }

            [JsonProperty("start")]
            public long Start { get; set; }

            [JsonProperty("subset")]
            public string Subset { get; set; }

            [JsonProperty("total")]
            public long Total { get; set; }
        }

        public class Food
        {
            [JsonProperty("measure")]
            public string Measure { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("ndbno")]
            public string Ndbno { get; set; }

            [JsonProperty("nutrients")]
            public Nutrient[] Nutrients { get; set; }

            [JsonProperty("weight")]
            public long Weight { get; set; }
        }

        public class Nutrient
        {
            [JsonProperty("gm")]
            public long Gm { get; set; }

            [JsonProperty("nutrient_id")]
            public string NutrientId { get; set; }

            [JsonProperty("nutrient")]
            public string PurpleNutrient { get; set; }

            [JsonProperty("unit")]
            public string Unit { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }
    }
