using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Interfaces.WordCloudRepository
{
    public interface IWordCloudRepository
    {
        Task<List<Show>> GetWordCloudAsync();
    }
}
