using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Users.Models
{
    public class User
    {
        public int Id { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("first_name")] public string FirstName { get; set; }
        [JsonProperty("last_name")] public string LastName { get; set; }
        [JsonProperty("avatar")] public string ImageUrl { get; set; }

        public string Name => string.Format("{0} {1}", FirstName, LastName);
    }
}
