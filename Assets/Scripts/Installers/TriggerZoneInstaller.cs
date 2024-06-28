using ScriptableObject;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class TriggerZoneInstaller : MonoInstaller
    {
        [SerializeField] private TriggerZoneConfig _config;
        public override void InstallBindings()
        {
            Container.Bind<TriggerZoneConfig>().FromScriptableObject(_config).AsSingle().NonLazy();
        }
    }

}