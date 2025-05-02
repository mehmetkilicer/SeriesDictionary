using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Application.Interfaces.WordInterfaces;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.Persistence.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly DictionaryContext _context;

        public WordRepository(DictionaryContext context)
        {
            _context = context;
        }


        public async Task<List<Word>> GetWordsByEpisodeIdAndDifficultyAsync(int episodeId, int difficultyId)
        {
            return await _context.WordEpisodes
                .Where(we => we.EpisodeId == episodeId && we.Word.DifficultyId == difficultyId)
                .Select(we => we.Word)
                .ToListAsync();
        }

        public async Task<List<Word>> GetRandomWordsAsync(int count)
        {
            return await _context.Words
                .OrderBy(w => Guid.NewGuid())
                .Take(count)
                .ToListAsync();
        }

        public async Task<Word> GetWordByIdAsync(int id)
        {
            return await _context.Words.FindAsync(id);
        }
    }
}
