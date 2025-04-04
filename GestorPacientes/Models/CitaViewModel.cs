namespace GestorPacientes.Models
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Birthdate { get; set; }
        public string HoraCita { get; set; }
        public string CausaCita { get; set; }
        public string EstadoCita { get; set; }
        public string PacienteName { get; set; }
        public string MedicoName { get; set; }

        public List<PacienteViewModel> Pacientes { get; set; } = new List<PacienteViewModel>();
        public List<MedicoViewModel> Medicos { get; set; } = new List<MedicoViewModel>();
    }
}
