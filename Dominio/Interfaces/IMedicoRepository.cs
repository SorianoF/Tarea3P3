using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllAsync();
        Task<Medico> GetByIdAsync(int id); 
        Task AddAsync(Medico entity);
        Task UpdateAsync(Medico entity);
        Task DeleteAsync(int id);
    }
}
