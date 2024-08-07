using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Enums;
using ScriptableObjects;
using Services.Factory;
using Services.ObjectPool;
using UnityEngine;
using Utils;
using Views.EnemySpawnPoint;

namespace Presenters.EnemySpawner
{

    public class EnemySpawnerPresenter
    {
        private readonly ObjectPool _enemyPool;
        private readonly SpawnerConfig _spawnerConfig;
        private readonly List<EnemySpawnPoint> _spawnPoints;
        
        public EnemySpawnerPresenter(IFactory enemyFactory, Transform parentTransform, SpawnerConfig spawnerConfig, List<EnemySpawnPoint> spawnPoints)
        {
            InvariantChecker.CheckObjectInvariant(spawnerConfig, spawnPoints);
            _enemyPool = new ObjectPool(enemyFactory, parentTransform);
            _spawnerConfig = spawnerConfig;
            _spawnPoints = spawnPoints;
        }

        public void Enable()
        {
            foreach (var keyValuePair in _spawnerConfig.TypeToDelay)
            {
                SpawnEnemy(keyValuePair).Forget();
            }
        }

        private async UniTaskVoid SpawnEnemy(SerializableKeyValuePair<EnemyType, float> keyValuePair)
        {
            while (true)
            {
                await UniTask.Delay((int) (keyValuePair.Value * 1000));
                Spawn(keyValuePair, out GameObject currentEnemy);
                PositionEnemy(currentEnemy);
            }
        }

        private void PositionEnemy(GameObject currentEnemy)
        {
            currentEnemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count - 1)].Position;
        }

        private void Spawn(SerializableKeyValuePair<EnemyType, float> keyValuePair, out GameObject currentEnemy)
        {
            currentEnemy = _enemyPool.Get(keyValuePair.Key);
            if (currentEnemy != null)
                currentEnemy.SetActive(true);
        }
    }

}