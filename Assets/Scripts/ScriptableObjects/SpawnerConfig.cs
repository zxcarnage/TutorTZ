using System.Collections.Generic;
using Enums;
using UnityEngine;
using Utils;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Spawner Config", menuName = "Config/Spawner", order = 0)]
    public class SpawnerConfig : ScriptableObject
    {
        [SerializeField] private List<SerializableKeyValuePair<EnemyType, float>> _typeToDelay;

        public List<SerializableKeyValuePair<EnemyType, float>> TypeToDelay => _typeToDelay;
    }

}