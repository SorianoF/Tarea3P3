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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        public async Task AddAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(Medico medico)
        {
            _context.Medicos.Update(medico);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await GetByIdAsync(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync(); 
            }
        }

    }
}
