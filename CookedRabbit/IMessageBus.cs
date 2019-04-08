using System;
using System.Collections.Generic;
using System.Text;

namespace CookedRabbit
{
    public interface ISimpleMessageBus
    {
		string GetCurrentQueueName();
		bool SetQueueName(string queueName);
		bool Send(string message);
		void Receive(OnReceived onReceived);
    }
}
