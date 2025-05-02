using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.QuizDto
{
    public class QuizViewModel
    {
        public int EpisodeId { get; set; }
        public string EpisodeTitle { get; set; }
        public List<QuizQuestionViewModel> Questions { get; set; }
    }
}
