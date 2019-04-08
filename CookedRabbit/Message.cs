using System;
using System.Collections.Generic;
using System.Text;

namespace CookedRabbit
{
	[Serializable]
    public class Message : IMessage
    {
		public  MessageType Type { get; set; }

		public string Payload { get; set; }

		public Message(MessageType type, string payload)
		{
			Type = type;
			Payload = payload;

		}

		public byte[] GetMessageBytes() {
			return Encoding.UTF8.GetBytes(Payload);
		}

		public void SetMessage(string payload)
		{
			Payload = payload;
		}

		public MessageType GetMessageType()
		{
			return Type;
		}

    }
}
