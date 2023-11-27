using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(p => p.Direccion).NotEmpty().WithMessage("La direccion no puede ser nula");
            RuleFor(p => p.Ciudad).NotEmpty().WithMessage("Ciudad no puede ser nula");
            RuleFor(p => p.Departamento).NotEmpty().WithMessage("Departamento no puede ser nulo");
            RuleFor(p => p.CodigoPostal).NotEmpty().WithMessage("CodigoPostal no puede ser nulo");
            RuleFor(p => p.Pais).NotEmpty().WithMessage("Pais no puede ser nulo");
        }
    }
}
