using Orangotango.MessageBus.RabbitMQ;
using Orangotango.MessageBus.Settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Orangotango.MessageBus.RabbitMQ
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

        public static string GetPayload(this BasicDeliverEventArgs args)
        {
            return Encoding.UTF8.GetString(args.Body.ToArray());
        }
    }
}
