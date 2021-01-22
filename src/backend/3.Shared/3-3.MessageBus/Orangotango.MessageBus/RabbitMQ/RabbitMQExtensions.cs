using RabbitMQ.Client;

namespace Orangotango.MessageBus
{
    public static class RabbitMQExtensions
    {
        public static IModel QueueDeclare(this IModel model, QueueSettings queueSettings)
        {
            model.QueueDeclare(queue: queueSettings.Name,
                               durable: queueSettings.Durable,
                               exclusive: queueSettings.AutoDelete,
                               autoDelete: queueSettings.AutoDelete);

            return model;
        }

        public static void BasicAck(this IModel channel, ulong tag, bool multiple = false)
        {
            channel?.BasicAck(tag, multiple);
        }
    }
}
