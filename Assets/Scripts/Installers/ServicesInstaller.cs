using Services.Factory;
using Zenject;
using IFactory = Services.Factory.IFactory;

namespace Installers
{

    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEnemyFactory();
        }

        private void BindEnemyFactory()
        {
            Container.Bind<IFactory>()
                .To<EnemyFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }

}