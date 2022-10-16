using MailingService;
using MailingService.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("mailing", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
        
    var info = JsonConvert.DeserializeObject<MailReceiveModel>(message);
    Mailing.Send(info.Email, JsonConvert.SerializeObject(info.Data));
};

channel.BasicConsume(queue: "mailing", autoAck: true, consumer: consumer);
Console.ReadKey();