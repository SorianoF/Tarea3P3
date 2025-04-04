using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public string PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public DateTime Birthdate { get; set; }
        public string HoraCita { get; set; }
        public string CausaCita { get; set; }
        public string EstadoCita { get; set; } 
    }
}
