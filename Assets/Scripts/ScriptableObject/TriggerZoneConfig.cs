using UnityEngine;

namespace ScriptableObject
{

    [CreateAssetMenu(fileName = "Trigger zone config", menuName = "Configs/Trigger zone Config", order = 0)]
    public class TriggerZoneConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _damageDelay;

        public float Damage => _damage;
        public float DamageDelay => _damageDelay;
    }

}