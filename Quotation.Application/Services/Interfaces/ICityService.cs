using MapsterMapper;
using Quotation.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces
{
    public interface ICityService
    {
        List<CityViewModel> GetAllCities();
        CityViewModel Create(CityViewModel city);

    }
}
