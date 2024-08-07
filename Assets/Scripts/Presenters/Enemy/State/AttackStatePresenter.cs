using Cysharp.Threading.Tasks;
using Models;
using ScriptableObjects;
using Utils;
using Views.StateMachine;
using Zenject;

namespace Presenters.Enemy.State
{
    public class AttackStatePresenter : IState
    {
        private readonly IHealthModel _playerHealthModel;
        private readonly EnemyConfig _config;

        private bool _attacked;
        
        public AttackStatePresenter([Inject(Source = InjectSources.Parent)] IHealthModel playerHealthModel, EnemyConfig config)
        {
            InvariantChecker.CheckObjectInvariant(playerHealthModel, config);

            _playerHealthModel = playerHealthModel;
            _config = config;

        }
        
        public void Enter()
        {
            //Анимка удара
            _attacked = false;
            DamageTask().Forget();
        }

        private async UniTaskVoid DamageTask()
        {
            await UniTask.Delay((int) (_config.AttackDelay * 1000));
            _playerHealthModel.Decrease(_config.Damage);
            _attacked = true;
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void ChangeState(StateMachineView stateMachineView)
        {
            if(_attacked == true)
                stateMachineView.SetState(typeof(MoveStatePresenter));
        }

        public void Exit()
        {
            
        }
    }

}