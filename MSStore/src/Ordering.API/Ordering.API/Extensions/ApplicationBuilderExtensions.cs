using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ordering.API.RabbitMQ;

namespace Ordering.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static EventBusRabbitMQConsumer Listener { get; set; }

        public static void UseRabbitListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusRabbitMQConsumer>();
            var lifeCycle = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            lifeCycle.ApplicationStarted.Register(OnStarted);
            lifeCycle.ApplicationStopping.Register(OnStopping);
        }

        private static void OnStarted()
        {

        }

        private static void OnStopping()
        {

        }
    }
}