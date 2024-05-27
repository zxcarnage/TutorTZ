using System;
using Player;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(Transform))]
    public class CameraFollowerView : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        private CameraFollowerPresenter _presenter;

        private void Awake()
        {
            _presenter = new CameraFollowerPresenter();
        }

        private void LateUpdate()
        {
            _presenter.FollowCamera(_playerView.transform, transform);
        }
    }
}