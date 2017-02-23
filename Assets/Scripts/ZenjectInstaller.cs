using Assets.Scripts.PlainEntities;
using Assets.Scripts.PlainEntities.Dispatcher;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ZenjectInstaller : MonoInstaller<ZenjectInstaller>
    {
        public override void InstallBindings()
        {
            //Debug.Log("Installing bindings...");
            Container.Bind<IDispatcher>().To<Dispatcher>().AsSingle();
            Container.Bind<IBombLevel>().To<BombLevelController>().AsSingle();

            // TODO: remove or create a method
            //var systems = Container.ResolveAll<IDispatcher>();
            //Debug.Log(string.Join(", ", systems.Select(x => x.GetType().Name).ToArray()));
        }
    }
}