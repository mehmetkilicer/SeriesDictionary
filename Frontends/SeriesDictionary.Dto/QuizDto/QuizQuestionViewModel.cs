using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.QuizDto
{
    public class QuizQuestionViewModel
    {
        public int WordId { get; set; }
        public string EnglishWord { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; }
    }  
}
