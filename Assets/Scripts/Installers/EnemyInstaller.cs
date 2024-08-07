using System.Collections.Generic;
using UnityEngine;
using Views.EnemySpawnPoint;
using Zenject;

namespace Installers
{

    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private List<EnemySpawnPoint> _spawnPoints;
        
        public override void InstallBindings()
        {
            BindEnemySpawnPoints();
        }

        private void BindEnemySpawnPoints()
        {
            Container.Bind<List<EnemySpawnPoint>>()
                .FromInstance(_spawnPoints)
                .AsSingle()
                .NonLazy();
        }
    }

}