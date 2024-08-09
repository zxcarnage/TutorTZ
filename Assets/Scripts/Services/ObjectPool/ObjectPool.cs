using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Services.Factory;
using UnityEngine;
using Utils;

namespace Services.ObjectPool
{
    public class ObjectPool
    {
        private readonly Dictionary<EnemyType, List<GameObject>> _enemyDictionary;
        private readonly IFactory _factory;
        private readonly Transform _parentTransform;
        
        private const int SpawnAmount = 1;

        public ObjectPool(IFactory factory, Transform parenTransform)
        {
            InvariantChecker.CheckObjectInvariant(factory, parenTransform);
            _enemyDictionary = new();
            _factory = factory;
            _parentTransform = parenTransform;
            Initialize();
        }

        private void Initialize()
        {
            var values = Enum.GetValues(typeof(EnemyType)).Cast<EnemyType>();
            foreach (var value in values)
            {
                var newObjectsContainer = _factory.CreateContainer(value.ToString(),_parentTransform).transform;
                _enemyDictionary[value] = new List<GameObject>();
                for (int i = 0; i < SpawnAmount; i++)
                {
                    var instantiated = _factory.Create(value, Vector2.zero, newObjectsContainer);
                    instantiated.SetActive(false);
                    _enemyDictionary[value].Add(instantiated);
                }
            }
        }

        public GameObject Get(EnemyType type)
        {
            return _enemyDictionary[type].FirstOrDefault(x => x.activeSelf == false);
        }
    }
}