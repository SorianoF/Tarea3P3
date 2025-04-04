using Application.DTOs;
using Application.Helpers;
using Dominio.Entities;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConsultorioRepository _consultorioRepository;

        public UserService(IUserRepository userRepository, IConsultorioRepository consultorioRepository)
        {
            _userRepository = userRepository;
            _consultorioRepository = consultorioRepository;
        }

        public void Register(RegisterUserDto dto)
        {
            // Validaciones básicas
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Las contraseñas no coinciden.");
            }

            var existingUser = _userRepository.GetByUsername(dto.Username);
            if (existingUser != null)
            {
                throw new Exception("El nombre de usuario ya existe.");
            }

            // Crear consultorio
            var consultorio = new Consultorio
            {
                Name = dto.ConsultorioName
            };
            _consultorioRepository.Add(consultorio);

            // Crear usuario
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = PasswordEncryption.ComputeSha256Hash(dto.Password),
                Consultorio = consultorio
            };
            _userRepository.Add(user);
        }

        public bool ValidateUser(LoginUserDto dto)
        {
            var user = _userRepository.GetByUsername(dto.Username);
            if (user == null) return false;

            var passwordHash = PasswordEncryption.ComputeSha256Hash(dto.Password);
            return user.PasswordHash == passwordHash;
        }
    }
}
