using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
