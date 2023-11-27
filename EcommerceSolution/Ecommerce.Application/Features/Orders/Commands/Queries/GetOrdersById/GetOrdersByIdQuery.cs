using Ecommerce.Application.Features.Orders.Vms;
using MediatR;
using MimeKit.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Orders.Commands.Queries.GetOrdersById
{
    public class GetOrdersByIdQuery : IRequest<OrderVm>
    {
        public int OrderId { get; set; }

        public GetOrdersByIdQuery(int orderId)
        {
            OrderId = orderId == 0 ? throw new ArgumentNullException(nameof(orderId)) : orderId;
        }
    }
}
