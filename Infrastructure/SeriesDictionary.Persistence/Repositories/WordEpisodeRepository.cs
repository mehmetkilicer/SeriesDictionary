using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Application.Interfaces.WordEpisodeInterfaces;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Dto.SeriesDto;
using SeriesDictionary.Dto.WordDto;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.Persistence.Repositories
{
    public class WordEpisodeRepository : IWordEpisodeRepository
    {
        private readonly DictionaryContext _context;

        public WordEpisodeRepository(DictionaryContext context)
        {
            _context = context;
        }

        public List<Word> GetAllWordsWithEpisode()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Word>> GetAWordsByEpisode(int id) // Dönüş türünü Task<List<Word>> yaptık
        {
            var episode = await _context.Episodes
                .Include(e => e.WordEpisodes)
                .ThenInclude(we => we.Word)
                .FirstOrDefaultAsync(e => e.Id == id); // id değişkenini kullandık

            if (episode != null)
            {
                return episode.WordEpisodes.Select(we => we.Word).ToList();
            }

            return new List<Word>();
        }


        public async Task<List<WordsByEpisodeAndDifficultyDto>> GetWordsByEpisodeAndDifficultyAsync(int episodeId, int difficultyId)
        {
            return await _context.Words
                .Where(w => w.DifficultyId == difficultyId &&
                            w.WordEpisodes.Any(we => we.EpisodeId == episodeId))
                .Select(w => new WordsByEpisodeAndDifficultyDto
                {
                    Id = w.Id,
                    English = w.English,
                    Turkish = w.Turkish,
                    DifficultyId = w.DifficultyId,
                    Sentence = w.Sentence,
                    Show = w.Show == null ? null : new ShowDto // Show bilgisi varsa DTO'ya aktar
                    {
                        Id = w.Show.Id,
                        Title = w.Show.Title,
                        Description = w.Show.Description,
                        Type = w.Show.Type,
                        ImageUrl1 = w.Show.ImageUrl1,
                        ImageUrl2 = w.Show.ImageUrl2,
                        ImageUrl3 = w.Show.ImageUrl3
                    }
                }).ToListAsync();
        }



    }
}
