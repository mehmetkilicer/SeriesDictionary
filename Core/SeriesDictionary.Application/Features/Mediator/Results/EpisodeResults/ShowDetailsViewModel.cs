using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Results.EpisodeResults
{
    public class ShowDetailsViewModel
    {
        public Show Show { get; set; }
        public List<SeasonViewModel> Seasons { get; set; }

        public ShowDetailsViewModel()
        {
            Seasons = new List<SeasonViewModel>();
        }
    }

    public class SeasonViewModel
    {
        public int SeasonNumber { get; set; }
        public List<Episode> Episodes { get; set; }

        public SeasonViewModel()
        {
            Episodes = new List<Episode>();
        }
    }

}
