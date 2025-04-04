using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly ApplicationDbContext _context;

        public CitaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<Cita> GetByIdAsync(int id)
        {
            return await _context.Citas.FindAsync(id);
        }

        public async Task AddAsync(Cita cita)
        {
            await _context.Citas.AddAsync(cita);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cita cita)
        {
            _context.Citas.Update(cita);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cita = await GetByIdAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                await _context.SaveChangesAsync();
            }
        }
    }
}
