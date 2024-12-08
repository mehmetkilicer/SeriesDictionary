using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class UserProgress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public bool IsCompleted { get; set; }
    }
}
