using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeriesDictionary.Application.Features.Mediator.Results.AppUserResults
{
    public class GetUserByIdQueryResult
    {
        [JsonProperty("appUserId")]
        public int AppUserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("appRoleId")]
        public int AppRoleId { get; set; }

        [JsonProperty("profileImage")]
        public string ProfileImage { get; set; }


    }
}
