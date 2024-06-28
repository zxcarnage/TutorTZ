using UnityEngine;

namespace ScriptableObject
{

    [CreateAssetMenu(fileName = "Player config", menuName = "Configs/Player Config", order = 0)]
    public class PlayerConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speed;
        
        public float MaxHealth => _maxHealth;
        public float Speed => _speed;
    }

}