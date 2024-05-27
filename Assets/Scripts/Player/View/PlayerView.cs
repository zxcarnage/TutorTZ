using System;
using Player.Presenter;
using UnityEngine;
using Visitor;
using Zone;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private HealthRegenPowerUp _powerUp;
        [SerializeField] private TriggerZone _triggerZone;
        
        private PlayerMovePresenter _movePresenter;
        private PlayerInputPresenter _inputPresenter;
        private PlayerStatsPresenter _playerStatsPresenter;
        private Rigidbody2D _rigidbody2D;

        public event Action<float> HealthChanged; 

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _movePresenter = new PlayerMovePresenter();
            _inputPresenter = new PlayerInputPresenter();
            _playerStatsPresenter = new PlayerStatsPresenter();

        }

        private void OnEnable()
        {
            _triggerZone.PlayerEnteredFireZone += DecreasePlayerHealth;
            _playerStatsPresenter.PlayerHealthChanged += OnPlayerHealthChanged;
        }

        private void OnDisable()
        {
            _triggerZone.PlayerEnteredFireZone -= DecreasePlayerHealth;
            _playerStatsPresenter.PlayerHealthChanged -= OnPlayerHealthChanged;
        }

        private void OnPlayerHealthChanged(float value)
        {
            HealthChanged?.Invoke(value);    
        }

        private void FixedUpdate()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                StartCoroutine(_powerUp.Visit(_playerStatsPresenter));
            var direction = _inputPresenter.HandleInput();
            _movePresenter.MovePlayer(_rigidbody2D, direction);
        }

        private void DecreasePlayerHealth(float value)
        {
            _playerStatsPresenter.DecreasePlayerHealth(value);
        }
        
        
    }
}
