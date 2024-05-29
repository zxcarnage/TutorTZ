using UnityEngine;

namespace ScriptableObject
{

    [CreateAssetMenu(fileName = "Regen Config", menuName = "Power Up Configs / Regen Config", order = 0)]
    public class RegenConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private float _regenValue;
        [SerializeField] private float _regenDelay;
        [SerializeField] private float _regenDuration;

        public float RegenValue => _regenValue;
        public float RegenDelay => _regenDelay;
        public float RegenDuration => _regenDuration;
    }

}