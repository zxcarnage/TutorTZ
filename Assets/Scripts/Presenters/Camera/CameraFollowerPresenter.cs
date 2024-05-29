using UnityEngine;

namespace Presenters.Camera
{
    public class CameraFollowerPresenter
    {
        private readonly float _cameraSmooth;
        public CameraFollowerPresenter(float cameraSmooth)
        {
            _cameraSmooth = cameraSmooth;
        }

        public void FollowCamera(Transform playerTransform, Transform cameraTransform)
        {
            var nextPostion = CalculateNextPosition(playerTransform, cameraTransform);
            cameraTransform.position = new Vector3(nextPostion.x, nextPostion.y, cameraTransform.position.z);
        }

        private Vector2 CalculateNextPosition(Transform playerTransform, Transform cameraTransform)
        {
            return Vector2.Lerp(cameraTransform.position,
                playerTransform.position,
                _cameraSmooth * Time.deltaTime);
        }
    }
}