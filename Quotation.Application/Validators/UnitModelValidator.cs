using FluentValidation;
using Quotation.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Validators
{
    public class UnitModelValidator : AbstractValidator<UnitViewModel>
    {
        public UnitModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3);
        }
    }
}
