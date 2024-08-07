using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Config/Player", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _maxHealth;

        public float MovementSpeed => _movementSpeed;
        public float MaxHealth => _maxHealth;
    }

}