using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Features.Mediator.Queries.WordQueries;
using SeriesDictionary.Application.Features.Mediator.Results.WordResults;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.WordHandlers
{
    //public class GetWordQueryHandler : IRequestHandler<GetWordQuery, List<GetWordQueryResult>>
    //{
    //    private readonly IRepository<Word> _repository;

    //    public GetWordQueryHandler(IRepository<Word> repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<List<GetWordQueryResult>> Handle(GetWordQuery request, CancellationToken cancellationToken)
    //    {
    //        var values = await _repository.GetAllAsync(); // Bu, veri sayfalama veya filtreleme yapılmadan tüm veriyi döndürüyor.

    //        return values.Select(x => new GetWordQueryResult
    //        {
    //            Id = x.Id,
    //            English = x.English,
    //            Turkish = x.Turkish,
    //            DifficultyId = x.DifficultyId // Burada DifficultyId'yi atamayı unutmayın
    //        }).ToList();
    //    }


    //}
}
