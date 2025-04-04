using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato de correo no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El nombre del consultorio es obligatorio")]
        public string ConsultorioName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}
