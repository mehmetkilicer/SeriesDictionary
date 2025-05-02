using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Application.Interfaces.LogoutInterface
{
    public interface ILogoutRepository

    {
        void InvalidateToken(string token);
        bool IsTokenValid(string token);
    }
}
