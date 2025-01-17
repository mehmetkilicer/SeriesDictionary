using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.WordQueries;
using SeriesDictionary.Application.Interfaces.WordEpisodeInterfaces;
using SeriesDictionary.Dto.WordDto;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.WordEpisodeHandlers
{
    public class GetWordsByEpisodeAndDifficultyQueryHandler : IRequestHandler<GetWordsByEpisodeAndDifficultyQuery, List<WordsByEpisodeAndDifficultyDto>>
    {
        private readonly IWordEpisodeRepository _wordRepository;

        public GetWordsByEpisodeAndDifficultyQueryHandler(IWordEpisodeRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<List<WordsByEpisodeAndDifficultyDto>> Handle(GetWordsByEpisodeAndDifficultyQuery request, CancellationToken cancellationToken)
        {
            // Repository'den doğrudan DTO listesi döndürülüyor
            var words = await _wordRepository.GetWordsByEpisodeAndDifficultyAsync(request.EpisodeId, request.DifficultyId);
            return words;
        }
    }
}
