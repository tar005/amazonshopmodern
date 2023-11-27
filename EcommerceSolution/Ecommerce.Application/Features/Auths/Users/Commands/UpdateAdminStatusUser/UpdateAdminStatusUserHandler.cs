﻿using Ecommerce.Application.Exceptions;
using Ecommerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Auths.Users.Commands.UpdateAdminStatusUser
{
    public class UpdateAdminStatusUserHandler : IRequestHandler<UpdateAdminStatusUserCommand, Usuario>
    {
        private readonly UserManager<Usuario> _userManager;

        public UpdateAdminStatusUserHandler(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Usuario> Handle(UpdateAdminStatusUserCommand request, CancellationToken cancellationToken)
        {
            var updateUsuario = await _userManager.FindByIdAsync(request.Id!);
            if(updateUsuario is null)
            {
                throw new BadRequestException("El usuario no existe");
            }

            updateUsuario.IsActive = !updateUsuario.IsActive;

            var resultado = await _userManager.UpdateAsync(updateUsuario);

            if(!resultado.Succeeded)
            {
                throw new Exception("No se pudo cambiar el estado del usuario");
            }

            return updateUsuario;
        }
    }
}
