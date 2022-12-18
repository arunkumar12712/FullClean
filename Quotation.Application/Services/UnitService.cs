using MapsterMapper;
using Quotation.Application.DTO;
using Quotation.Application.Interface;
using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public UnitService(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public UnitDTO CreateUnit(UnitDTO unit)
        {
            var result  = _mapper.Map<Unit>(unit);
            var response =_unitRepository.CreateUnit(result);
            return _mapper.Map<UnitDTO>(response);
        }

        public bool DeleteUnit(int id)
        {
            var result = _unitRepository.GetUnitById(id);
            if(result == null)
            {
                // tesing
                return false;
            }
            _unitRepository.DeleteUnitById(result);
            return true;
        }

        public List<UnitDTO> GetAllUnits()
        {
            var result = _unitRepository.GetAllUnits();
            return _mapper.Map<List<UnitDTO>>(result);
        }

        public UnitDTO GetUnitById(int id)
        {
            var result =_unitRepository.GetUnitById(id);
            return _mapper.Map<UnitDTO>(result);
        }

        public UnitDTO UpdateUnit(UnitDTO unit)
        {
            var result = _mapper.Map<Unit>(unit);
            var response = _unitRepository.UpdateUnit(result);
            return _mapper.Map<UnitDTO>(response);
        }
    }
}
