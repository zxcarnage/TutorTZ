using Presenters.Camera;
using UnityEngine;
using Views;

namespace EntryPoints.MainGame
{
    public class CameraFollowerEntryPoint : MonoBehaviour
    {
        [SerializeField] private CameraFollowerView _cameraFollowerView;

        [Space(10)] [Header("Camera Follow Settings")] 
        [SerializeField] private float _cameraSmooth;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;
        
        private CameraFollowerPresenter _cameraFollowerPresenter;
        

        private void Awake()
        {
            CreatePresenters();
            InitializeViews();
        }

        private void CreatePresenters()
        {
            _cameraFollowerPresenter = new CameraFollowerPresenter(_targetTransform, _cameraTransform, _cameraSmooth);
        }

        private void InitializeViews()
        {
            _cameraFollowerView.Initialize(_cameraFollowerPresenter, _targetTransform);
        }
    }
}