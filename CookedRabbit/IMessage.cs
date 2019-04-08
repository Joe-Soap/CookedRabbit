using System;
using System.Collections.Generic;
using System.Text;

namespace CookedRabbit
{
    public interface IMessage
    {
		MessageType Type { get; set; }
		string Payload { get; set; }
		byte[] GetMessageBytes();
		MessageType GetMessageType();

    }
}
