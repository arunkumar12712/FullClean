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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper  mapper) 
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public CityViewModel Create(CityViewModel city)
        {
            var result = _mapper.Map<City>(city);
            var response = _cityRepository.CreateCity(result);
            return _mapper.Map<CityViewModel>(response);
        }

        public List<CityViewModel> GetAllCities()
        {
            var result =  _cityRepository.GetAllCities();
            return _mapper.Map<List<CityViewModel>>(result); ;
        }
    }
}
