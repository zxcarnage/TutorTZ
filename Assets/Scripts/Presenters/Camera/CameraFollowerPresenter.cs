using System;
using UnityEngine;
using Utils;

namespace Presenters.Camera
{
    public class CameraFollowerPresenter
    {
        private readonly Transform _playerTransform;
        private readonly Transform _cameraTransform;
        private readonly float _cameraSmooth;
        public CameraFollowerPresenter(Transform playerTransform, Transform cameraTransform,float cameraSmooth)
        {
            InvariantChecker.CheckObjectInvariant(playerTransform, cameraTransform);
            if (cameraSmooth <= 0 || cameraSmooth > 1)
                throw new ArgumentOutOfRangeException();
            _cameraSmooth = cameraSmooth;
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;
        }

        public void FollowCamera()
        {
            var nextPostion = CalculateNextPosition();
            _cameraTransform.position = new Vector3(nextPostion.x, nextPostion.y, _cameraTransform.position.z);
        }

        private Vector2 CalculateNextPosition()
        {
            return Vector2.Lerp(_cameraTransform.position,
                _playerTransform.position,
                _cameraSmooth * Time.deltaTime);
        }
    }
}