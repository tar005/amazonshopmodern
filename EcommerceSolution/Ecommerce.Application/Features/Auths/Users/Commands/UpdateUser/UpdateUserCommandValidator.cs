using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Auths.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(p => p.Nombre).NotEmpty().WithMessage("El nombre no puede ser nulo");
            RuleFor(p => p.Apellido).NotEmpty().WithMessage("El apellido no puede ser nulo");
        }
    }
}
