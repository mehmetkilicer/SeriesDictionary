using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Application.Features.Mediator.Results.QuizResults
{
    public class IncorrectAnswerViewModel
    {
        public int WordId { get; set; }
        public string EnglishWord { get; set; }
        public string CorrectAnswer { get; set; }
        public string SelectedAnswer { get; set; }
    }
}
