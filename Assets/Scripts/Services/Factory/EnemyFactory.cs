using System;
using Enums;
using UnityEngine;
using Zenject;
using Object = System.Object;

namespace Services.Factory
{
    public class EnemyFactory : IFactory
    {
        private readonly DiContainer _container;

        private const string EnemyPath = "Enemies/";
        private const string SlimeEnemy = EnemyPath + "Slime";
        private const string EnemyException = "Enemy doesn't exist!";

        private Object _slime;
        
        public EnemyFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _slime = Resources.Load(SlimeEnemy);
        }

        public GameObject Create(EnemyType type, Vector2 at, Transform parent = null)
        {
            switch (type)
            {
                case EnemyType.Slime:
                     return _container.InstantiatePrefab(_slime as GameObject, at, Quaternion.identity, parent);
                default:
                    throw new ArgumentOutOfRangeException(EnemyException);
            }
        }

        public GameObject CreateContainer(string containerName, Transform parent)
        {
            var obj = _container.Instantiate(typeof(GameObject)) as GameObject;
            obj.name = containerName;
            obj.transform.SetParent(parent);
            return obj;
        }
    }
}