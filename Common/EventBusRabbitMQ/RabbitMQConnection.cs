using RabbitMQ.Client;

namespace EventBusRabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        public bool IsConnected => throw new System.NotImplementedException();

        public IModel CreateModel()
        {
            throw new System.NotImplementedException();
        }

        public bool TryConnect()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}