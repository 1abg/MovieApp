namespace MovieApp.API.MessageQueue
{
    public interface IMessageQueueProducer
    {
        void SendMessage<T>(string queueName, T message, string exchange = "");
    }
}
