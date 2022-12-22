using FluentValidation;
using Quotation.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Validators
{
    public class UnitModelValidator : AbstractValidator<UnitDTO>
    {
        public UnitModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3);
        }
    }
}
