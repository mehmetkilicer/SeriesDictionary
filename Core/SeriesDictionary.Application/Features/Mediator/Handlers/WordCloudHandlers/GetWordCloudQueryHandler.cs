using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;
using SeriesDictionary.Application.Interfaces.WordCloudRepository;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.WordCloudHandlers
{
    public class GetWordCloudQueryHandler : IRequestHandler<GetWordCloudQuery, List<GetWordCloudQueryResult>>
    {
        public readonly IWordCloudRepository _wordCloudRepository;

        public GetWordCloudQueryHandler(IWordCloudRepository wordCloudRepository)
        {
            _wordCloudRepository = wordCloudRepository;
        }

        public async Task<List<GetWordCloudQueryResult>> Handle(GetWordCloudQuery request, CancellationToken cancellationToken)
        {
            var WordCloud = await _wordCloudRepository.GetWordCloudAsync();
            return WordCloud.Select(wordcloud => new GetWordCloudQueryResult
            {
                Id = wordcloud.Id,
                Title = wordcloud.Title,
                Description = wordcloud.Description,
                ImageUrl1 = wordcloud.ImageUrl1,
                ImageUrl2 = wordcloud.ImageUrl2,
                ImageUrl3 = wordcloud.ImageUrl3
            }).ToList();
        }
    }
}
