using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces;

public class GetSeriesQueryHandler : IRequestHandler<GetSeriesQuery, List<GetSeriesQueryResult>>
{
    private readonly ISeriesRepository _seriesRepository;

    public GetSeriesQueryHandler(ISeriesRepository seriesRepository)
    {
        _seriesRepository = seriesRepository;
    }

    public async Task<List<GetSeriesQueryResult>> Handle(GetSeriesQuery request, CancellationToken cancellationToken)
    {
        var series = await _seriesRepository.GetSeriesAsync();

        return series.Select(s => new GetSeriesQueryResult
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
            ImageUrl1 = s.ImageUrl1,
            ImageUrl2 = s.ImageUrl2,
            ImageUrl3 = s.ImageUrl3
        }).ToList();
    }
}
