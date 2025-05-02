using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Dto.WordDto;

namespace SeriesDictionary.Application.Interfaces.WordEpisodeInterfaces
{
    public interface IWordEpisodeRepository
    {
        List<Word> GetAllWordsWithEpisode();
        Task<List<Word>> GetAWordsByEpisode(int id);


        Task<List<WordsByEpisodeAndDifficultyDto>> GetWordsByEpisodeAndDifficultyAsync(int episodeId, int difficultyId);

        Task<Episode> GetEpisodeByIdAsync(int episodeId);

    }
}
