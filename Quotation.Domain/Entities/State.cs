using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Domain.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
