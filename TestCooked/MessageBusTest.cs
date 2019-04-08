using System;
using Xunit;
using Moq;
using CookedRabbit;

namespace TestCooked
{
    public class MessageBusTest
    {
		//This is one example. I did not have more time to implement an exhaustive test suite.
        [Fact]
        public void InitializeDefaultsTest()
        {
			var messageBus = new Interactor();
			Assert.Equal("default", messageBus.GetCurrentQueueName());
        }
    }
}
