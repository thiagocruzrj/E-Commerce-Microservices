using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    public class GetOrderByUserNameHandler : IRequestHandler<GetOrderByUserNameQuery, IEnumerable<OrderResponse>>
    {
        public Task<IEnumerable<OrderResponse>> Handle(GetOrderByUserNameQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}