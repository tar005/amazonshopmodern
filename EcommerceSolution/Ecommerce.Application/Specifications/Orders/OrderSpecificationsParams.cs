﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Specifications.Orders
{
    public class OrderSpecificationsParams : SpecificationParams
    {
        public string? Username { get; set; }
        public int? Id { get; set; }
    }
}
