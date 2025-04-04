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
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllPacientes()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
        }

        public async Task<PacienteDTO> GetPacienteById(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            return _mapper.Map<PacienteDTO>(paciente);
        }

        public async Task AddPaciente(PacienteDTO pacienteDTO)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDTO);
            await _pacienteRepository.AddAsync(paciente);
        }

        public async Task UpdatePaciente(PacienteDTO pacienteDTO)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDTO);
            await _pacienteRepository.UpdateAsync(paciente);
        }

        public async Task DeletePaciente(int id)
        {
            await _pacienteRepository.DeleteAsync(id);
        }
    }
}
