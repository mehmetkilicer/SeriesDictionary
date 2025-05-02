using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Application.Interfaces.AppUserInterfaces;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.Persistence.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DictionaryContext _context;
        public AppUserRepository(DictionaryContext context)
        {
            _context = context;
        }
        public Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
