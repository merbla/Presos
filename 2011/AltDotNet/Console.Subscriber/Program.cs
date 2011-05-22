using System.Text;
using Merbla.Common;
using Merbla.Common.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using Merbla.Common;
namespace Console.Subscriber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory {HostName = Settings.RabbitMqHost};

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    var subscription = new Subscription(model, Settings.RabbitMqQueue, false);
                    while (true)
                    {
                        var basicDeliveryEventArgs = subscription.Next();
                        var messageContent = basicDeliveryEventArgs.Body.To<SimpleMessage>();
                        System.Console.WriteLine(messageContent.Content);
                        subscription.Ack(basicDeliveryEventArgs);
                    }
                }
            }

            System.Console.ReadLine();
        }
    }
}