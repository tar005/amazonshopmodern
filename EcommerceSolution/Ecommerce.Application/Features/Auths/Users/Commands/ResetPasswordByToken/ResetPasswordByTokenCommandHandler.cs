using Ecommerce.Application.Exceptions;
using Ecommerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Auths.Users.Commands.ResetPasswordByToken
{
    public class ResetPasswordByTokenCommandHandler : IRequestHandler<ResetPasswordByTokenCommand, string>
    {
        private readonly UserManager<Usuario> _userManager;

        public ResetPasswordByTokenCommandHandler(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(ResetPasswordByTokenCommand request, CancellationToken cancellationToken)
        {
            if(string.Equals(request.Password, request.ConfirmPassword))
            {
                throw new BadRequestException("El password no es igual a la confirmación del password");
            }

            var updateUsuario = await _userManager.FindByEmailAsync(request.Email!);

            if (updateUsuario is null)
            {
                throw new BadRequestException("El email no está registrado como usuario");
            }

            var token = Convert.FromBase64String(request.Token!);
            var tokenResult = Encoding.UTF8.GetString(token);

            var resetResultado = await _userManager.ResetPasswordAsync(updateUsuario, tokenResult, request.Password!);

            if(!resetResultado.Succeeded)
            {
                throw new Exception("No se pudo resetear el password");
            }

            return $"Se actualizó exitosamente tu password {request.Email}";
        }
    }
}
