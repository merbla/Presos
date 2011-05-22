using System.Configuration;

namespace Merbla.Common
{
    public class Settings
    {
        public static string RabbitMqHost
        {
            get { return ConfigurationManager.AppSettings["RabbitMqHost"]; }
        }

        public static string RabbitMqExchange
        {
            get { return ConfigurationManager.AppSettings["RabbitMqExchange"]; }
        }

        public static string RabbitMqQueue
        {
            get { return ConfigurationManager.AppSettings["RabbitMqQueue"]; }
        }
    }
}