using Models;
using Models.Health;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers
{
    public class InPlayerInstaller : MonoInstaller<InPlayerInstaller>
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void InstallBindings()
        {
            BindPlayerRigidbody();
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