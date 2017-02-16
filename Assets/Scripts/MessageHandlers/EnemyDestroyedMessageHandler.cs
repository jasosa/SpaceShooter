using System;
using UnityEngine;
using Assets.Scripts.MessageBus;
using Assets.Scripts.Entities;

namespace Assets.Scripts.MessageHandlers
{
	public class EnemyDestroyedMessageHandler : MessageHandler
	{
		public override void HandleMessage(EnemyDestroyedMessage message)
		{
			ScoreFactory.GetScore ().AddScore ();  
		}
	}
}