using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers.Config
{

    public class ConfigInstaller : MonoInstaller <ConfigInstaller>
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings()
        {
            BindEnemyConfig();
        }

        private void BindEnemyConfig()
        {
            Container.Bind<EnemyConfig>()
                .FromScriptableObject(_enemyConfig)
                .AsSingle()
                .NonLazy();
        }
    }

}