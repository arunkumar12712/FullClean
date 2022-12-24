using Mapster;
using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.ViewModel
{
    public class CompanyViewModel : IRegister
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string GSTNo { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public int StateId { get; set; }
        public virtual State? State { get; set; }
        public int CityId { get; set; }
        public virtual City? City { get; set; }


        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Company, CompanyViewModel>();
        }
    }
}
