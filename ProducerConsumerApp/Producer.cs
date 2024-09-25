using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerApp
{
    public class Producer
    {
        public static ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
        public static int successCount = 0;
        public static int failureCount = 0;
        public Consumer _consumer;

        public Producer() 
        {
            _consumer = new Consumer();
        }
        public void AddMessage(string message)
        {
            messageQueue.Enqueue(message);

            lock (ProducerConsumer.consoleLock)
            {   
                Console.WriteLine("Your message added successfully, Waiting for Process");
            }
        }
    }
}
