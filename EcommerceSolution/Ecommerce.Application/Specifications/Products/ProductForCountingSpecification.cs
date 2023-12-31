﻿using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Specifications.Products
{
    public class ProductForCountingSpecification : BaseSpecification<Product>
    {
        public ProductForCountingSpecification(ProductSpecificationParams productParams) : base
            ( x => (string.IsNullOrEmpty(productParams.Search) || x.Nombre!.Contains(productParams.Search) || x.Descripcion!.Contains(productParams.Search)) && 
            (!productParams.CategoryId.HasValue || x.CategoryId == productParams.CategoryId) && 
            (!productParams.PrecioMin.HasValue || x.Precio >= productParams.PrecioMin) &&
            (!productParams.PrecioMax.HasValue || x.Precio <= productParams.PrecioMax) &&
            (!productParams.Status.HasValue || x.Status == productParams.Status))
        {
        }
    }
}
