using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUserRepository
    {
        Entities.User GetByUsername(string username);
        void Add(Entities.User user); 
    }
}
