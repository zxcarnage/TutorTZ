using Models.Player;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Installers.GameObjectInstallers
{
    public class InPlayerInstaller : MonoInstaller<InPlayerInstaller>
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void InstallBindings()
        {
            BindPlayerRigidbody();
            BindHealthModel();
        }

        private void BindHealthModel()
        {
            Container.Bind<HealthModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerRigidbody()
        {
            Container.Bind<Rigidbody2D>()
                .FromInstance(_rigidbody)
                .AsSingle()
                .NonLazy();
        }
        
    }

}