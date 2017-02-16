using System;
using System.Collections.Generic;

namespace Assets.Scripts.MessageBus
{
	public class MessageBus
	{
		Dictionary<MessageType, List<MessageSusbscriber>> subscribersByType = new Dictionary<MessageType, List<MessageSusbscriber>> ();

		public void AddSusbcriber (MessageSusbscriber subscriber)
		{
			for (int i = 0; i < subscriber.MessageTypes.Length; i++)
				AddSubscriberToMessage (subscriber.MessageTypes[i], subscriber);
		}


		public void SendMessage (EnemyDestroyedMessage message)
		{
			if (!this.subscribersByType.ContainsKey (message.Type))
				return;

			List<MessageSusbscriber> subscriberList = 
				subscribersByType[message.Type];

			for (int i = 0; i < subscriberList.Count; i++)
				subscriberList [i].Handler.HandleMessage (message);
		}

		void AddSubscriberToMessage ( MessageType messageType, 
			MessageSusbscriber subscriber)
		{
			if (!subscribersByType.ContainsKey (messageType))
				subscribersByType[messageType] = 
					new List<MessageSusbscriber> ();

			subscribersByType [messageType].Add (subscriber);
		}

		/* Singleton */
		static MessageBus instance;

		public static MessageBus Instance
		{
			get
			{
				if(instance == null)
					instance = new MessageBus();

				return instance;
			}
		}

		private MessageBus() {}
	}
}

