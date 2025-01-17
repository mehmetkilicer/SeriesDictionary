using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Application.Interfaces.SeriesInterfaces
{
    using global::SeriesDictionary.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace SeriesDictionary.Application.Interfaces
    {
        public interface IShowRepository
        {
            Task<Show> GetShowByIdAsync(int id);
            Task<List<Episode>> GetEpisodesByShowIdAsync(int showId);
        }
    }

}
