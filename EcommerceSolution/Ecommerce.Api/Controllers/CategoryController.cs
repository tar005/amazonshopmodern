﻿    using global::Ecommerce.Application.Features.Categories.Queries.GetCategoryList;
    using global::Ecommerce.Application.Features.Categories.Vms;
    using global::Ecommerce.Application.Features.Countries.Queries.GetCountryList;
    using global::Ecommerce.Application.Features.Countries.Vms;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    namespace Ecommerce.Api.Controllers
    {
        [ApiController]
        [Route("api/v1/[controller]")]
        public class CategoryController : ControllerBase
        {
            private IMediator _mediator;

            public CategoryController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [AllowAnonymous]
            [HttpGet("list", Name = "GetCategoryList")]
            [ProducesResponseType(typeof(IReadOnlyList<CategoryVm>), (int)HttpStatusCode.OK)]
            public async Task<ActionResult<IReadOnlyList<CategoryVm>>> GetCategoryList()
            {
                var query = new GetCategoryListQuery();
                return Ok(await _mediator.Send(query));
            }
        }
    }

