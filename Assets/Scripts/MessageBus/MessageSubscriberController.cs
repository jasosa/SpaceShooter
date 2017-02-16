using UnityEngine;
using System;

namespace Assets.Scripts.MessageBus
{
	public class MessageSubscriberController : MonoBehaviour
	{
		public MessageType[] MessageTypes;
		public MessageHandler Handler;

		void Start()
		{
			MessageSusbscriber subscriber = new MessageSusbscriber ();
			subscriber.MessageTypes = MessageTypes;
			subscriber.Handler = Handler;
			MessageBus.Instance.AddSusbcriber (subscriber);
		}
	}
}

