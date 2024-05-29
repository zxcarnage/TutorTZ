using Presenters.Camera;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Transform))]
    public class CameraFollowerView : MonoBehaviour
    {
        private Transform _targetTransform;
        private CameraFollowerPresenter _presenter;
        private Transform _cameraTransform;

        public void Initialize(CameraFollowerPresenter presenter, Transform targetTransform)
        {
            _presenter = presenter;
            _targetTransform = targetTransform;
            _cameraTransform = transform;
        }

        private void LateUpdate()
        {
            _presenter.FollowCamera(_targetTransform, _cameraTransform);
        }
    }
}