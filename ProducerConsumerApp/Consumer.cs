using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerApp
{
    public class Consumer
    {
        public void ParseMessage()
        {
            while (true)
            {
                if (Producer.messageQueue.TryDequeue(out string message))
                {
                    try
                    {
                        lock (ProducerConsumer.consoleLock)
                        {  
                            Console.WriteLine($"Your requested completed successfully for {message}");
                            Producer.successCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        lock (ProducerConsumer.consoleLock)
                        {
                            Console.WriteLine("Some error occured while parsing your request.");
                            Producer.failureCount++;
                        }
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
