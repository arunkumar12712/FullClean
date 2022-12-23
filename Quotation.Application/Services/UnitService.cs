using MapsterMapper;
using Quotation.Application.Repositories.Interface;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.ViewModel;
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

        public UnitViewModel CreateUnit(UnitViewModel unit)
        {
            var result  = _mapper.Map<Unit>(unit);
            var response =_unitRepository.CreateUnit(result);
            return _mapper.Map<UnitViewModel>(response);
        }

        public bool DeleteUnit(int id)
        {
            var result = _unitRepository.GetUnitById(id);
            if(result == null)
            {
                return false;
            }
            _unitRepository.DeleteUnitById(result);
            return true;
        }

        public List<UnitViewModel> GetAllUnits()
        {
            var result = _unitRepository.GetAllUnits();
            return _mapper.Map<List<UnitViewModel>>(result);
        }

        public UnitViewModel GetUnitById(int id)
        {
            var result =_unitRepository.GetUnitById(id);
            return _mapper.Map<UnitViewModel>(result);
        }

        public UnitViewModel UpdateUnit(UnitViewModel unit)
        {
            var result = _mapper.Map<Unit>(unit);
            var response = _unitRepository.UpdateUnit(result);
            return _mapper.Map<UnitViewModel>(response);
        }
    }
}
