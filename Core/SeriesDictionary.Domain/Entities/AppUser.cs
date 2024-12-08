using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }

        // Relationships
        public ICollection<UserProgress> UserProgresses { get; set; }
        public ICollection<UserStatistics> UserStatistics { get; set; }
        public ICollection<UserWord> UserWords { get; set; }

        public AppUser()
        {
            UserProgresses = new List<UserProgress>();
            UserStatistics = new List<UserStatistics>();
            UserWords = new List<UserWord>();
        }
    }
}
