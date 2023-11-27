using Ecommerce.Application.Features.Auths.Users.Vms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Auths.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameQuery : IRequest<AuthResponse>
    {
        public string? Username { get; set; }

        public GetUserByUsernameQuery(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(Username));
        }
    }
}
