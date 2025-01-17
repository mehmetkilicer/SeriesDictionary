using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Interfaces.SeriesInterfaces
{
    public interface ISeriesRepository
    {
        Task<List<Show>> GetSeriesAsync();
    }
}
