using Ecommerce.Application.Features.Reviews.Queries.Vms;
using Ecommerce.Application.Features.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Reviews.Queries.PaginationReviews
{
    public class PaginationReviewsQuery : PaginationBaseQuery, IRequest<PaginationVm<ReviewVm>>
    {
        public int? ProductId { get; set; }
        public int? Rating { get; set; }
    }
}
