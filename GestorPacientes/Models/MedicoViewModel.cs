namespace GestorPacientes.Models
{
    public class MedicoViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Cedula { get; set; }       
        public int ConsultorioId { get; set; }        
        public string ConsultorioName { get; set; }
    }
}
