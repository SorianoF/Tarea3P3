using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoService _medicoService;
        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        public async Task<IActionResult> Index()
        {
            var medicos = await _medicoService.GetAllMedicos();
            return View(medicos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicoDTO medicoDTO)
        {
            if (ModelState.IsValid)
            {
                await _medicoService.AddMedico(medicoDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(medicoDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medico = await _medicoService.GetMedicoById(id);
            if (medico == null) return NotFound();
            return View(medico);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MedicoDTO medicoDTO)
        {
            if (ModelState.IsValid)
            {
                await _medicoService.UpdateMedico(medicoDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(medicoDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var medico = await _medicoService.GetMedicoById(id);
            if (medico == null) return NotFound();
            return View(medico);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _medicoService.DeleteMedico(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
