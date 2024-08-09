using System;
using Presenters.Enemy.State;
using ScriptableObjects;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Views.Enemy.EnemyStateMachine.State
{

    public class MoveStateView : StateView
    {
        private MoveStatePresenter _presenter;
        
        [Inject]
        protected void Initialize(EnemyConfig enemyConfig, PlayerMoveView playerMoveView, Rigidbody2D enemyRigidbody)
        {
            _presenter = new MoveStatePresenter(enemyConfig, playerMoveView, enemyRigidbody, TransitionViews);
        }

        protected override void FixedUpdate()
        {
            _presenter.FixedUpdate();
        }

        public override StateView GetNext()
        {
            return _presenter.GetNext();
        }
    }

}