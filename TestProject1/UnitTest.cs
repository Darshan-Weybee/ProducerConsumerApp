using Microsoft.VisualStudio.TestPlatform.Utilities;
using ProducerConsumerApp;

namespace TestProject1
{
    public class UnitTest
    {
        [Fact]
        public void Test_ProducerConsumer_Success()
        {
            Producer producer = new Producer();
            Consumer consumer = new Consumer();

            Thread consumerThread = new Thread(consumer.ParseMessage);
            consumerThread.IsBackground = true;
            consumerThread.Start();

            producer.AddMessage("Message 1");
            Thread.Sleep(1000);

            Assert.Equal(1, Producer.successCount);
            Assert.Equal(0, Producer.failureCount);
        }

        [Fact]
        public void Test_ProducerConsumer_Failure()
        {
            Producer producer = new Producer();
            Consumer consumer = new Consumer();

            Thread consumerThread = new Thread(consumer.ParseMessage);
            consumerThread.IsBackground = true;
            consumerThread.Start();

            producer.AddMessage("");
            Thread.Sleep(1000);

            Assert.Equal(0, Producer.successCount);
            Assert.Equal(1, Producer.failureCount);
        }
    }
}