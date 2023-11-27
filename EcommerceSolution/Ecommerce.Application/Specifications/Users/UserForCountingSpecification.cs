using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Specifications.Users
{
    public class UserForCountingSpecification : BaseSpecification<Usuario>
    {
        public UserForCountingSpecification(UserSpecificationParams userParams) : base(
            x =>
            (string.IsNullOrEmpty(userParams.Search) || x.Nombre!.Contains(userParams.Search)
            || x.Apellido!.Contains(userParams.Search) || x.Email!.Contains(userParams.Search)
            )
        )
        { 
        
        }
    }
}
