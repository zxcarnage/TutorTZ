using UnityEngine;
using Utils;
using Zenject;

namespace Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineService _coroutineService;
        public override void InstallBindings()
        {
            Container.Bind<CoroutineService>().FromComponentInNewPrefab(_coroutineService).AsSingle().NonLazy();
        }
    }
}