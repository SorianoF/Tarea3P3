using Application.DTOs;
using Application.Services;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AccountController(AuthService authService, UserService usuarioService)
        {
            _authService = authService;
            _userService = usuarioService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto dto)
        {
            if (_authService.Login(dto))
            {
                return RedirectToAction("Index", "Home"); 
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserDto dto) 
        {
            try
            {
                _userService.Register(dto); 
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message); 
                return View();
            }
        }
    }
}
