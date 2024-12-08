using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Application.Features.Mediator.Results.QuizQuestionResults
{
    public class GetQuizQuestionQueryResult
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}
