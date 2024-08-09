using Models;
using Models.Health;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers
{

    public class InEnemyInstaller: MonoInstaller <InEnemyInstaller>
    {
        [SerializeField] private Rigidbody2D _enemyRigidbody;

        public override void InstallBindings()
        {
            BindHealthModel();
            BindRigidbody();
        }

        private void BindRigidbody()
        {
            Container.Bind<Rigidbody2D>()
                .FromInstance(_enemyRigidbody)
                .AsSingle()
                .NonLazy();
        }

        private void BindHealthModel()
        {
            Container.Bind<IHealthModel>()
                .To<EnemyHealthModel>()
                .AsSingle()
                .NonLazy();
        }
    }

}