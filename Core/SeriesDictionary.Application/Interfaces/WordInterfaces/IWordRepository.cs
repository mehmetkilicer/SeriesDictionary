using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Interfaces.WordInterfaces
{
    public interface IWordRepository
    {
        Task<List<Word>> GetWordsByEpisodeIdAndDifficultyAsync(int episodeId, int difficultyId);
        Task<List<Word>> GetRandomWordsAsync(int count);

        Task<Word> GetWordByIdAsync(int id);

    }
}
