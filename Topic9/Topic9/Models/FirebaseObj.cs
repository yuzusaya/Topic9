using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Topic9.Models
{
    public class FirebaseObj
    {
        [JsonIgnore]
        public string Key { get; set; }
    }
}
