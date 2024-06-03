using Models.Player;
using Presenters.Damageable;
using Presenters.Healthbar;
using Presenters.Player;
using ScriptableObject;
using UnityEngine;
using Utils;
using Views.Damageable;
using Views.Healthbar;
using Views.Player;

namespace EntryPoints.MainGame
{
    public class PlayerEntryPoint : MonoBehaviour
    {
        [SerializeField] private CoroutineService _coroutineService;
        
        [Header("Views")]
        [SerializeField] private HealthbarView _healthbarView;
        [SerializeField] private HealthbarWithTextView _healthbarWithTextView;
        [SerializeField] private PlayerRegenPowerUpView _playerRegenPowerUpView;
        [SerializeField] private PlayerMoveView _playerMoveView;
        [SerializeField] private DamageableView _playerDamageableView;

        [Space(10)] [Header("Config")]
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private RegenConfig _regenConfig;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _playerMaxHealth;
        
        private HealthModel _playerHealthModel;
        
        private HealthbarPresenter _healthbarPresenter;
        private PlayerRegenPresenter _playerRegenPresenter;
        private PlayerMovePresenter _playerMovePresenter;
        private DamageablePresenter _playerDamageablePresenter;

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
            _playerHealthModel = new HealthModel(_playerMaxHealth);
        }
        
        private void CreatePresenters()
        {
            _playerRegenPresenter = new PlayerRegenPresenter(_coroutineService, _regenConfig, _playerHealthModel);
            _playerMovePresenter = new PlayerMovePresenter(_playerRigidbody,_playerSpeed);
            _playerDamageablePresenter = new DamageablePresenter(_playerDamageableView, _playerHealthModel);
        }
        
        private void InitializeViews()
        {
            _healthbarView.Initialize(_playerHealthModel);
            _healthbarWithTextView.Initialize(_playerHealthModel);
            _playerRegenPowerUpView.Initialize(_playerRegenPresenter);
            _playerMoveView.Initialize(_playerMovePresenter);
        }
    }
}