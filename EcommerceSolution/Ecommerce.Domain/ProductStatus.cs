﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public enum ProductStatus
    {
        [EnumMember(Value = "Producto Inactivo")]
        Inactivo,
        [EnumMember(Value = "Producto Activo")]
        Activo
    }
}
