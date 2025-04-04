﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Consultorio
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public List<User> users { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}
