using System;

namespace Assets.Scripts.MessageBus
{
	public interface IMessageHandler
	{
		void HandleMessage( EnemyDestroyedMessage message );
	}
}

