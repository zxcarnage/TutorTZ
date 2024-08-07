using System;
using UnityEngine;

namespace Views.EnemySpawnPoint
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public Vector2 Position { get; private set; }

        private void Awake()
        {
            Position = transform.position;
        }
    }
}