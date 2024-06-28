using System;
using ScriptableObject;
using UnityEngine;
using Utils;
using Views.Entity;
using Views.Player;

namespace Presenters.Camera
{
    public class CameraFollowerPresenter
    {
        private readonly Transform _playerTransform;
        private readonly Transform _cameraTransform;
        private readonly float _cameraSmooth;
        
        public CameraFollowerPresenter(PlayerMoveView player, Transform cameraTransform, CameraConfig cameraConfig)
        {
            InvariantChecker.CheckObjectInvariant(player, cameraTransform);
            _cameraSmooth = cameraConfig.Smooth;
            if (_cameraSmooth <= 0 || _cameraSmooth > 1)
                throw new ArgumentOutOfRangeException();
            _playerTransform = player.transform;
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