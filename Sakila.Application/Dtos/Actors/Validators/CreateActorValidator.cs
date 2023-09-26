using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Sakila.Application.Dtos.Actors.Validators
{
    public class CreateActorValidator : AbstractValidator<CreateActor>
    {
        public CreateActorValidator()
        {
            RuleFor(x => x.First_Name).NotEmpty().Length(3, 45);
            RuleFor(x => x.Last_Name).NotEmpty().Length(3, 45);
        }
    }
}
