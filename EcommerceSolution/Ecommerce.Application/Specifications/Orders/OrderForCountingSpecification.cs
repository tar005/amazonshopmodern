using Ecommerce.Application.Specifications.Reviews;
using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Specifications.Orders
{
    public class OrderForCountingSpecification : BaseSpecification<Order>
    {
        public OrderForCountingSpecification(OrderSpecificationsParams orderParams) : base(
            x =>
            (string.IsNullOrEmpty(orderParams.Username) ||
            x.CompradorUsername!.Contains(orderParams.Username)) &&
            (!orderParams.Id.HasValue || x.Id == orderParams.Id)
            )
        {
        }
    }
}
