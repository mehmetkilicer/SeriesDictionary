using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.CategoryWordsComands
{
    public class RemoveCategoryWordsCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryWordsCommand(int id)
        {
            Id = id;
        }
    }
}
