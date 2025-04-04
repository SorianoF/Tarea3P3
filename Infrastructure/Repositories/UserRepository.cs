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
    public class UserRepository : IUserRepository 
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dominio.Entities.User GetByUsername(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.Username == userName);
        }

        public void Add(Dominio.Entities.User user)
        {
            _context.Users.Add(user);  
            _context.SaveChanges();
        }

    }
}