using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class CitaController : Controller
    {
        private readonly CitaService _citaService;

        public CitaController(CitaService citaService)
        {
            _citaService = citaService;
        }      
        public async Task<IActionResult> Index()
        {
            var citas = await _citaService.GetAllCitas();
            return View(citas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CitaDTO citaDTO)
        {
            if (ModelState.IsValid)
            {
                await _citaService.AddCita(citaDTO);
                return RedirectToAction(nameof(Create));
            }
            return View(citaDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cita = await _citaService.GetCitaById(id);
            if (cita == null) return NotFound();
            return View(cita);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CitaDTO citaDTO)
        {
            if (ModelState.IsValid)
            {
                await _citaService.UpdateCita(citaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(citaDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cita = await _citaService.GetCitaById(id);
            if (cita == null) return NotFound();
            return View(cita);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _citaService.DeleteCita(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
