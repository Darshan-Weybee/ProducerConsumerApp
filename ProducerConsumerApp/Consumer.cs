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
                        if (string.IsNullOrEmpty(message))
                            throw new Exception("Request is not valid.");

                        lock (ProducerConsumer.consoleLock)
                        {  
                            Console.WriteLine($"Successfull : Your requested completed successfully for {message}");
                            Producer.successCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        lock (ProducerConsumer.consoleLock)
                        {
                            Console.WriteLine("Unsuccessfull : Some error occured while parsing your request.");
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
