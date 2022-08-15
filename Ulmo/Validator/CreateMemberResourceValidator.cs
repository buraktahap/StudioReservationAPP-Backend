using FluentValidation;
using StudioReservationAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioReservationAPP.Validator
{
    public class CreateMemberResourceValidator : AbstractValidator<CreateMemberDto>
    {
        public CreateMemberResourceValidator()
        {
            RuleFor(a => a.Name)
              .NotEmpty()
              .MaximumLength(50);
        }
    }
}