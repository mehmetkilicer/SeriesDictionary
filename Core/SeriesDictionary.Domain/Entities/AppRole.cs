using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class AppRole
    {
        public int AppRoleId { get; set; }
        public string AppRoleName { get; set; }

        // Relationships
        public ICollection<AppUser> AppUsers { get; set; }

        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }
    }
}
