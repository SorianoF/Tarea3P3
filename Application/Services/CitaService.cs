using Application.DTOs;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public CitaService(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CitaDTO>> GetAllCitas()
        {
            var citas = await _citaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CitaDTO>>(citas);
        }

        public async Task<CitaDTO> GetCitaById(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            return _mapper.Map<CitaDTO>(cita);
        }

        public async Task AddCita(CitaDTO citaDTO)
        {
            var cita = _mapper.Map<Cita>(citaDTO);
            await _citaRepository.AddAsync(cita);
        }

        public async Task UpdateCita(CitaDTO citaDTO)
        {
            var cita = _mapper.Map<Cita>(citaDTO);
            await _citaRepository.UpdateAsync(cita);
        }

        public async Task DeleteCita(int id)
        {
            await _citaRepository.DeleteAsync(id);
        }
    }
}
