﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMqProducer
{
   public static class QueueProducer
    {
        public static void Producer(IModel channel) {
            channel.QueueDeclare("demo-queue",
               durable: true, exclusive: false, autoDelete: false, arguments: null);
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"hello , {count}" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
