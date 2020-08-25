using MediatR;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Queries
{
    public class GetOrderByUseerNameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderByUseerNameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentException(nameof(userName));
        }
    }
}