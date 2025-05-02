using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.Persistence.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly DictionaryContext _context;

        public SeriesRepository(DictionaryContext context)
        {
            _context = context;
        }

        public async Task<List<Show>> GetSeriesAndMovieAsync()
        {
            return await _context.Show
                .Where(show => show.Type == "Dizi" || show.Type == "Film") // Hem Dizi hem Film olanları getir
                .ToListAsync();
        }


        public async Task<List<Show>> GetSeriesAsync()
        {
            return await _context.Show
                .Where(show => show.Type == "Dizi") // "Dizi" türündeki gösterimler
                .ToListAsync();
        }
    }
}
