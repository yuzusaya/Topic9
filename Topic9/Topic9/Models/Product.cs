using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Topic9.Models
{
    public class Product : FirebaseObj
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
