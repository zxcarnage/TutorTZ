using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.Enemy.EnemyStateMachine;
using Views.Player;
using Views.StateMachine;

namespace Presenters.Enemy.State
{
    public class MoveStatePresenter : IState
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly Transform _target;
        private readonly Rigidbody2D _enemyRigidbody;

        private Vector2 _movementVector;
        
        public MoveStatePresenter(EnemyConfig enemyConfig, PlayerMoveView target, Rigidbody2D enemyRigidbody2D)
        {
            InvariantChecker.CheckObjectInvariant(enemyConfig, target, enemyRigidbody2D);
            _enemyConfig = enemyConfig;
            _target = target.transform;
            _enemyRigidbody = enemyRigidbody2D;
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            _movementVector = ((Vector2) _target.position - _enemyRigidbody.position) 
                              * _enemyConfig.MovementSpeed * Time.fixedDeltaTime;
            _enemyRigidbody.velocity = _movementVector;
        }

        public void ChangeState(StateMachineView stateMachineView)
        {
            if(Vector2.Distance(_enemyRigidbody.position, _target.position) <= _enemyConfig.AttackDistance)
                stateMachineView.SetState(typeof(AttackStatePresenter));
        }

        public void Exit()
        {
            
        }
    }
}