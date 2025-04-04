using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumbre { get; set; }
        public string Cedula { get; set; }
        public int CusultorioId { get; set; }
        public Consultorio Consultorio { get; set; }
    }
}
