using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Application.Features.Mediator.Queries.QuizQueries;
using SeriesDictionary.Dto.QuizDto;

namespace SeriesDictionary.Application.Features.Mediator.Results.QuizResults
{
    public class QuizResultViewModel
    {
        public int CorrectAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public List<IncorrectAnswerViewModel> IncorrectAnswers { get; set; }
        public List<QuizQuestionViewModel> Questions { get; set; } // Yeni eklenen özellik



    }
}
