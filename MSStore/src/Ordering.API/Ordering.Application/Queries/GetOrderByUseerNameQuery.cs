using MediatR;
using System.Collections.Generic;

namespace Ordering.Application.Queries
{
    public class GetOrderByUseerNameQuery : IRequest<IEnumerable<OrderResponse>>
    {
    }
}