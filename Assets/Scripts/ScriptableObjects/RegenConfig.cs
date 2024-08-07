using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Regen Config", menuName = "Config/Power ups/Regen Config", order = 0)]
    public class RegenConfig : ScriptableObject
    {
        [SerializeField] private float _regenValue;
        [SerializeField] private float _regenDelay;
        [SerializeField] private float _regenDuration;

        public float RegenValue => _regenValue;
        public float RegenDelay => _regenDelay;
        public float RegenDuration => _regenDuration;
    }

}