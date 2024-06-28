using UnityEngine;

namespace ScriptableObject
{

    [CreateAssetMenu(fileName = "Camera config", menuName = "Configs/Camera Config", order = 0)]
    public class CameraConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private float _smooth;

        public float Smooth => _smooth;
    }

}