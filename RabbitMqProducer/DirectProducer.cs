using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMqProducer
{
   public static class DirectProducer
    {
        public static void Producer(IModel channel,string name, string lastName)
        {
            channel.ExchangeDeclare("demo-direct-exchange",ExchangeType.Direct);
                var message = new { Name = name, Message = lastName };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("demo-direct-exchange", "account.init", null, body);
               
        }
    }
}
