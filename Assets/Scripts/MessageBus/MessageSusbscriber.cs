using System;

namespace Assets.Scripts.MessageBus
{
	public struct MessageSusbscriber
	{
		public MessageType[] MessageTypes;
		public MessageHandler Handler;
	}
}

