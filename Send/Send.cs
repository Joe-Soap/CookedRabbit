using System;
using RabbitMQ.Client;
using System.Text;
using CookedRabbit;


namespace WongaAssessment
{



	class Send
	{

		

		public static void Main()
		{
			Console.WriteLine("Please enter your name >");
			var name = Console.ReadLine();
			
			var	controller = new CookedRabbitController(new Interactor("localhost", "introductions"));	
			
			if (controller.Send($"Hello my name is, {name}"))
			{
				Console.WriteLine("Message sent successfully");
			}
			else
			{
				Console.WriteLine("Message failed to send");
			}
			
			
			Console.WriteLine("Press [enter] to exit.");
			Console.ReadLine();
		}
	}
}