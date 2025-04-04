using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.GetAllPacientes();
            return View(pacientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteDTO pacienteDTO)
        {
            if (ModelState.IsValid)
            {
                await _pacienteService.AddPaciente(pacienteDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _pacienteService.GetPacienteById(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PacienteDTO pacienteDTO)
        {
            if (ModelState.IsValid)
            {
                await _pacienteService.UpdatePaciente(pacienteDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _pacienteService.GetPacienteById(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pacienteService.DeletePaciente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
