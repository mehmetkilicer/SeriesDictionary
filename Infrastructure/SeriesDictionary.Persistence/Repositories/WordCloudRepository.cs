using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Application.Interfaces.WordCloudRepository;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.Persistence.Repositories
{

    public class WordCloudRepository : IWordCloudRepository
    {
        private readonly DictionaryContext _context;

        public WordCloudRepository(DictionaryContext context)
        {
            _context = context;
        }

        public async Task<List<Show>> GetWordCloudAsync()
        {
            return await _context.Show
            .Where(show => show.Type == "WordCloud")
            .ToListAsync();
        }
    }
}
