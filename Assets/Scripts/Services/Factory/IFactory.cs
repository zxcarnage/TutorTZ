using Enums;
using UnityEngine;

namespace Services.Factory
{

    public interface IFactory
    {
        public GameObject Create(EnemyType type, Vector2 at, Transform parent = null);

        public GameObject CreateContainer(string containerName, Transform parent);
    }

}