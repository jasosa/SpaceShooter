using UnityEngine;
using System.Collections;

namespace Assets.Scripts.MessageBus
{
	public abstract class MessageHandler : MonoBehaviour
	{
		public abstract void HandleMessage( EnemyDestroyedMessage message );
	}
}

