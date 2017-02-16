using System;

namespace Assets.Scripts.MessageBus
{
	public class EnemyDestroyedMessage
	{
		public EnemyDestroyedMessage ()
		{
			
		}

		public MessageType Type 
		{
			get
			{
				return MessageType.EnemyDestroyed;   
			}	
		}
	}
}

