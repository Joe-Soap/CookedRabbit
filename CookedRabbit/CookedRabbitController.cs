using System;
using System.Collections.Generic;
using System.Text;


namespace CookedRabbit
{
	public delegate void OnReceived(string message);
	public delegate bool Validate(string message);
    
	public class CookedRabbitController
    {
		public Validate validate;
		ISimpleMessageBus MessageBus;

		public CookedRabbitController(ISimpleMessageBus messageBus)
		{
			MessageBus = messageBus;
		}

		public bool Send(string message)
		{
			try
			{
				MessageBus.Send(message);
			} catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public void Receive(OnReceived received) {

			Console.WriteLine($"Consuming from queue {MessageBus.GetCurrentQueueName()}");
			MessageBus.Receive(received);
		}

    }
}
