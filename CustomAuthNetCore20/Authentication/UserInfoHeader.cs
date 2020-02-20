using System.Collections.Generic;
using Newtonsoft.Json;

namespace CustomAuthNetCore20.Authentication
{
    public class UserInfoHeader
    {
        public ICollection<string> Groups { get; set; }

        [JsonProperty("user.fullName")]
        public string UserFullName { get; set; }

        [JsonProperty("user.Email")]
        public string UserEmail { get; set; }

        public string Sub { get; set; }
    }
}
