using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using ProducerConsumerApp;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Consumer_Method()
        {
            var producer = new Producer();
            var consumer = new Consumer();

            //producer.Add

            //Assert.Contains("Successfull : Your requested completed successfully", output);
            //Assert.Equal(1, Producer.successCount);
        }
    }
}
