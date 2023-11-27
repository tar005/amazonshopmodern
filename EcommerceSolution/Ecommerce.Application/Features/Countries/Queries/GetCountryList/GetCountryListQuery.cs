﻿using Ecommerce.Application.Features.Countries.Vms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Countries.Queries.GetCountryList
{
    public class GetCountryListQuery : IRequest<IReadOnlyList<CountryVm>>
    {
    }
}
