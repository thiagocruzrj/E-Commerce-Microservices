using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ordering.Infra.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                orderContext.Database.Migrate();

                if(!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(GetPreconfiguredOrders());
                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if(retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(ex.Message, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
    }
}