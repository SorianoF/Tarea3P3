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
    public class MedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public MedicoService(IMedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicoDTO>> GetAllMedicos()
        {
            var medicos = await _medicoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicoDTO>>(medicos);
        }

        public async Task<MedicoDTO> GetMedicoById(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);
            return _mapper.Map<MedicoDTO>(medico);
        }

        public async Task AddMedico(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            await _medicoRepository.AddAsync(medico);
        }

        public async Task UpdateMedico(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            await _medicoRepository.UpdateAsync(medico);
        }

        public async Task DeleteMedico(int id)
        {
            await _medicoRepository.DeleteAsync(id);
        }
    }
}
