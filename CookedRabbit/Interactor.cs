using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CookedRabbit
{
	public class Interactor : IDisposable, ISimpleMessageBus
	{
		private ConnectionFactory factory { get; set; }
		private IConnection connection { get; set; }
		private IModel channel { get; set; }
		private string QueueName { get; set; }
		private EventingBasicConsumer consumer { get; set; }

		public Interactor(string hostName = "localhost", string queueName = "default")
		{
			QueueName = queueName;
			factory = new ConnectionFactory() { HostName = hostName };
			connection = factory.CreateConnection();
			channel = connection.CreateModel();

		}

		public bool Send(string message) 
		{
			Message toSend = new Message(MessageType.NAME, message);
			
			try {
				return SendInternal(toSend);
			}
			catch (Exception ex)
			{
				return false;
			}

		}

		public bool SendInternal(IMessage message, string routingKey = "introductions")
		{
			
			try
			{

				channel.QueueDeclare(queue: QueueName,
										 durable: false,
										 exclusive: false,
										 autoDelete: false,
										 arguments: null);

				

				channel.BasicPublish(exchange: "",
									 routingKey: routingKey,
									 basicProperties: null,
									 body: message.GetMessageBytes());

				return true;

			}
			catch (Exception ex)
			{
				return false;
			}
			
		}

		public void Dispose()
		{
			channel = null;
			connection = null;
			factory = null;
		}
		
		public bool SetQueueName(string queueName)
		{
			QueueName = queueName;
			return true;
		}

		public void Receive(OnReceived onReceived)
		{

			channel.QueueDeclare(queue: QueueName,
										 durable: false,
										 exclusive: false,
										 autoDelete: false,
										 arguments: null);

			consumer = new EventingBasicConsumer(channel);

			consumer.Received += (model, ea) =>
			{
				var messageBytes = ea.Body;
				var message = Encoding.UTF8.GetString(messageBytes);

				onReceived(message);
			};

			channel.BasicConsume(queue: QueueName,
								 autoAck: true,
								 consumer: consumer);
			

		}

		public string GetCurrentQueueName() 
		{
			return QueueName;
		}
		
	}
}