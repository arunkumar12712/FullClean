using Mapster;
using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.ViewModel
{
    public class StateViewModel : IRegister
    {
        public int Id { get;set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<State, StateViewModel>();
        }
    }
}
