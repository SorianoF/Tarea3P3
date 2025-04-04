using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> GetAllAsync();
        Task<Cita> GetByIdAsync(int id);
        Task AddAsync(Cita cita);
        Task UpdateAsync(Cita cita);
        Task DeleteAsync(int id);
    }
}
