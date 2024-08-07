using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Trigger Zone Config", menuName = "Config/Trigger Zone", order = 0)]
    public class TriggerZoneConfig : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _damageDelay;

        public float Damage => _damage;
        public float DamageDelay => _damageDelay;
    }

}