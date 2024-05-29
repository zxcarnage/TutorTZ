using System;
using System.Collections.Generic;
using Models.Player;
using Presenters.Camera;
using Presenters.Healthbar;
using Presenters.Player;
using Presenters.TriggerZone;
using ScriptableObject;
using UnityEngine;
using Views;
using Views.Healthbar;
using Views.Player;

namespace EntryPoint
{
    public class MainGameEntryPoint : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private TriggerZoneView _triggerView;
        [SerializeField] private CameraFollowerView _cameraFollowerView;
        [SerializeField] private HealthbarView _healthbarView;
        [SerializeField] private HealthbarWithTextView _healthbarWithTextView;
        [SerializeField] private PlayerRegenPowerUpView _playerRegenPowerUpView;
        [SerializeField] private PlayerMoveView _playerMoveView;

        [Space(10)] [Header("Trigger Zone Settings")] 
        [SerializeField] private float _triggerDamage;
        [SerializeField] private float _triggerDamageDelay;

        [Space(10)] [Header("Camera Follow Settings")] 
        [SerializeField] private float _cameraSmooth;
        [SerializeField] private Transform _targetTransform;
        
        [Space(10)] [Header("Health Regen Config")] 
        [SerializeField] private RegenConfig _regenConfig;

        [Space(10)] [Header("Player config")] 
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private float _playerSpeed;

        private HealthModel _healthModel;

        private TriggerZonePresenter _triggerZonePresenter;
        private CameraFollowerPresenter _cameraFollowerPresenter;
        private HealthbarPresenter _healthbarPresenter;
        private PlayerRegenPresenter _playerRegenPresenter;
        private PlayerMovePresenter _playerMovePresenter;

        private void Awake()
        {
            CreateModels();
            CreatePresenters();
            InitializeViews();
            
        }

        private void OnEnable()
        {
            EnableViews();
        }

        private void OnDisable()
        {
            DisableViews();
        }

        private void EnableViews()
        {
            _healthbarView.Enable();
            _healthbarWithTextView.Enable();
        }

        private void DisableViews()
        {
            _healthbarView.Disable();
            _healthbarWithTextView.Disable();
        }

        private void CreateModels()
        {
            _healthModel = new HealthModel();
        }

        private void CreatePresenters()
        {
            _triggerZonePresenter = new TriggerZonePresenter(_healthModel, _triggerDamage, _triggerDamageDelay);
            _cameraFollowerPresenter = new CameraFollowerPresenter(_cameraSmooth);
            _healthbarPresenter = new HealthbarPresenter(_healthModel, new List<HealthbarView>()
            {
                _healthbarView, 
                _healthbarWithTextView
            });
            _playerRegenPresenter = new PlayerRegenPresenter(_regenConfig, _healthModel);
            _playerMovePresenter = new PlayerMovePresenter(_playerRigidbody,_playerSpeed);
        }

        private void InitializeViews()
        {
            _triggerView.Initialize(_triggerZonePresenter);
            _cameraFollowerView.Initialize(_cameraFollowerPresenter, _targetTransform);
            _healthbarView.Initialize(_healthbarPresenter);
            _healthbarWithTextView.Initialize(_healthbarPresenter);
            _playerRegenPowerUpView.Initialize(_playerRegenPresenter);
            _playerMoveView.Initialize(_playerMovePresenter);
        }
    }
}