using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properties.Validators
{
    public class NewPropertyValidator : AbstractValidator<NewProperty>
    {
        public NewPropertyValidator()
        {
            RuleFor(np => np.Name)
                .NotEmpty().WithMessage("Property name is required")
                .MaximumLength(10).WithMessage("Name should not exceed 15 characters");
        }
    }
}
