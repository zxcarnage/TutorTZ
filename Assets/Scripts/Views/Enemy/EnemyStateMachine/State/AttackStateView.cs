using Models;
using Presenters.Enemy.State;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.Enemy.EnemyStateMachine.State
{

    public class AttackStateView : StateView
    {
        private AttackStatePresenter _presenter;

        [Inject]
        public void Initialize([Inject(Source = InjectSources.Parent)]IHealthModel playerHealthModel, EnemyConfig config, Rigidbody2D enemyRigidbody)
        {
            _presenter = new AttackStatePresenter(playerHealthModel, config, TransitionViews, enemyRigidbody);
        }
        
        public override StateView GetNext()
        {
            return _presenter.GetNext();
        }

        public override async void Enter()
        {
            base.Enter();
            await _presenter.Enter();
        }

        public override void Exit()
        {
            _presenter.Exit();
            base.Exit();
        }
    }

}