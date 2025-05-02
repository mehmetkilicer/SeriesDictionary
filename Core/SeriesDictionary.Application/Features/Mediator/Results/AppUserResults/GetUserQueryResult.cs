using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Application.Features.Mediator.Results.AppUserResults
{
    public class GetUserQueryResult
    {
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int AppRoleId { get; set; }
        public string ProfileImage { get; set; }
    }
}
