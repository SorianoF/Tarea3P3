namespace GestorPacientes.Models
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Cedula { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Smoker { get; set; }
        public string Allergies { get; set; }       
        public int ConsultorioId { get; set; }
        public string ConsultorioName { get; set; }
    }
}
