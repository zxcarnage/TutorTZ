using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Camera Config", menuName = "Config/Camera", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        [SerializeField] private float _cameraSmooth;

        public float CameraSmooth => _cameraSmooth;
    }

}