using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MovieApp.API.MessageQueue.RabbitMQ
{
    public class RabbitMQProducer : IMessageQueueProducer
    {
        public void SendMessage<T>(string queueName, T message, string exchange = "")
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            
            var connection = factory.CreateConnection();
            
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queueName, exclusive: false);
            
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            channel.BasicPublish(exchange: exchange, routingKey: queueName, body: body);
        }
    }
}
