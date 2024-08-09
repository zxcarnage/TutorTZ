using ScriptableObjects;
using UnityEngine;
using Utils;
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
        private bool _shouldAttack = false;
        
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
            _movementVector = ((Vector2) _target.position - _enemyRigidbody.position).normalized 
                              * _enemyConfig.MovementSpeed * Time.fixedDeltaTime;
            _enemyRigidbody.velocity = _movementVector;
        }

        public void ChangeState(StateMachineView stateMachineView)
        {
            if(_shouldAttack == true)
                stateMachineView.SetState(typeof(AttackStatePresenter));
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerMoveView playerMoveView))
                _shouldAttack = true;
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerMoveView playerMoveView))
                _shouldAttack = false;
        }


        public void Exit()
        {
            
        }
    }
}