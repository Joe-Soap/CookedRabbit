using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using CookedRabbit;

namespace WongaAssessment
{

	class Receive
	{
		public static void Main()
		{
			var controller = new CookedRabbitController(new Interactor("localhost", "introductions"));
			controller.Receive((message) =>
			{
				// message must start with "Hello my name is, "
				string validationString = "Hello my name is, ";
				if (message.Substring(0, validationString.Length) != validationString)
				{
					Console.WriteLine("Message received that is not valid");
					return;
				}

				string ReceivedName = message.Substring(validationString.Length, message.Length - validationString.Length);

				Console.WriteLine($"Hello {ReceivedName}, I am your father!");

			});

			
		}
	}
} 
	