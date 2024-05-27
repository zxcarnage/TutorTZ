using UnityEngine;

namespace Camera
{
    public class CameraFollowerPresenter
    {
        private CameraFollowerModel _model;
        public CameraFollowerPresenter()
        {
            _model = new CameraFollowerModel(0.9f);
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
                _model.Smooth * Time.deltaTime);
        }
    }
}