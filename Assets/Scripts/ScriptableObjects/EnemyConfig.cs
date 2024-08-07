using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Enemy config", menuName = "Config/Enemy", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _attackDelay;

        public float MovementSpeed => _movementSpeed;
        public float Damage => _damage;
        public float AttackDistance => _attackDistance;
        public float AttackDelay => _attackDelay;
    }

}