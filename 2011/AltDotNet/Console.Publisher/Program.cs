using System.Collections.Generic;
using System.Text;
using Merbla.Common;
using Merbla.Common.Messages;
using RabbitMQ.Client;

namespace Console.Publisher
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
                    model.ExchangeDeclare(Settings.RabbitMqExchange, ExchangeType.Fanout);
                    model.QueueDeclare(Settings.RabbitMqQueue, true, false, true, new Dictionary<string, object>());
                    model.QueueBind(Settings.RabbitMqQueue, Settings.RabbitMqExchange, string.Empty,new Dictionary<string, object>());

                    var publicationAddress = new PublicationAddress(ExchangeType.Fanout, Settings.RabbitMqExchange, string.Empty);
                    var basicProperties = model.CreateBasicProperties();

                    var simpleMessage = new SimpleMessage {Content = "Simple Message"};

                    model.BasicPublish(Settings.RabbitMqExchange, "", false, false, basicProperties, simpleMessage.ToByteArray());
                     
                }
            }

            System.Console.ReadLine();
        }
    }
}