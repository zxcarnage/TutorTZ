using System;
using System.Collections.Generic;
using Presenters.EnemySpawner;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using IFactory = Services.Factory.IFactory;

namespace Views.EnemySpawner
{

    public class EnemySpawnerView : MonoBehaviour
    {
        private EnemySpawnerPresenter _presenter;

        [Inject]
        public void Initialize(IFactory factory, SpawnerConfig spawnerConfig, List<EnemySpawnPoint.EnemySpawnPoint> spawnPoints)
        {
            _presenter = new EnemySpawnerPresenter(factory, transform, spawnerConfig, spawnPoints);
        }

        private void Start()
        {
            _presenter.Enable();
        }
    }

}