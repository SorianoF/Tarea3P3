using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string CausaCita { get; set; }
        public string EstadoCita { get; set; }
    }
}
