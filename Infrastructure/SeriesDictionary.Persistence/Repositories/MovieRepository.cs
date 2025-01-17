using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Application.Interfaces.MovieInterface;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DictionaryContext _context;

        public MovieRepository(DictionaryContext context)
        {
            _context = context;
        }

        public async Task<List<Show>> GetMoviesAsync()
        {
          
            return await _context.Show
                .Where(show => show.Type == "Film")
                .ToListAsync();
        }
    }
}
