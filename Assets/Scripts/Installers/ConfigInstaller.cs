using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private RegenConfig _regenConfig;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private TriggerZoneConfig _triggerZoneConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private SpawnerConfig _spawnerConfig;
        
        public override void InstallBindings()
        {
            BindRegenConfig();
            BindPlayerConfig();
            BindTriggerZoneConfig();
            BindCameraConfig();
            BindSpawnerConfig();
        }

        private void BindSpawnerConfig()
        {
            Container.Bind<SpawnerConfig>()
                .FromScriptableObject(_spawnerConfig)
                .AsSingle()
                .NonLazy();
        }

        private void BindCameraConfig()
        {
            Container.Bind<CameraConfig>()
                .FromScriptableObject(_cameraConfig)
                .AsSingle()
                .NonLazy();
        }

        private void BindTriggerZoneConfig()
        {
            Container.Bind<TriggerZoneConfig>()
                .FromScriptableObject(_triggerZoneConfig)
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerConfig()
        {
            Container.Bind<PlayerConfig>()
                .FromScriptableObject(_playerConfig)
                .AsSingle()
                .NonLazy();
        }

        private void BindRegenConfig()
        {
            Container.Bind<RegenConfig>()
                .FromScriptableObject(_regenConfig)
                .AsSingle()
                .NonLazy();
        }
    }

}