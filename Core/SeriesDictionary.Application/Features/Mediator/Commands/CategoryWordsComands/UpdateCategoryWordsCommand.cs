using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.CategoryWordsComands
{
    public class UpdateCategoryWordsCommand : IRequest
    {
        public int CategoryId { get; set; }
        public int WordId { get; set; }
    }
}
