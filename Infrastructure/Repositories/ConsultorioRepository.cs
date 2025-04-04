using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ConsultorioRepository : IConsultorioRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultorioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Consultorio consultorio)
        {
            _context.Consultorios.Add(consultorio);
            _context.SaveChanges();
        }
    }
}
