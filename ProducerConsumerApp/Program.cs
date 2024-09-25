
namespace ProducerConsumerApp
{
    public class ProducerConsumer
    {
        public static readonly object consoleLock = new object();
        public static void Main(string[] args)
        {
            Producer producer = new Producer();
            Consumer consumer = new Consumer();

            Thread consumerThread = new Thread(consumer.ParseMessage);
            consumerThread.IsBackground = true;
            consumerThread.Start();

            while (true)
            {
                lock (consoleLock)
                {   
                    Console.WriteLine("Please enter your request");
            
                    string message = Console.ReadLine();

                    producer.AddMessage(message);
                }

                lock (consoleLock)
                {
                    Console.WriteLine("Want to add one more request? y/n");

                    string checkForProceed = Console.ReadLine();

                    if (checkForProceed.Equals("y", StringComparison.OrdinalIgnoreCase)) continue;
                    else break;
                }
            
            }
            Console.ReadKey();
        }
    }
}