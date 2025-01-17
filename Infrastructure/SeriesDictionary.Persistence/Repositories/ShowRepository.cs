using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces.SeriesDictionary.Application.Interfaces;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.Persistence.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly DictionaryContext _context;

        public ShowRepository(DictionaryContext context)
        {
            _context = context;
        }

        public async Task<Show> GetShowByIdAsync(int id)
        {
            // Include Episodes to ensure they are loaded
            return await _context.Show
                                 .Include(s => s.Episodes)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Episode>> GetEpisodesByShowIdAsync(int showId)
        {
            return await _context.Episodes
                                 .Where(e => e.ShowId == showId)
                                 .ToListAsync();
        }
    }

}
