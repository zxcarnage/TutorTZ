using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.Enemy.EnemyStateMachine.Transition;
using Views.Player;

namespace Presenters.Enemy.State
{
    public class MoveStatePresenter : StatePresenter
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly Transform _target;
        private readonly Rigidbody2D _enemyRigidbody;

        private Vector2 _movementVector;

        public MoveStatePresenter(EnemyConfig enemyConfig, PlayerMoveView target, Rigidbody2D enemyRigidbody2D, List<TransitionView> transition) : base(transition)
        {
            InvariantChecker.CheckObjectInvariant(enemyConfig, target, enemyRigidbody2D, transition);
            _enemyConfig = enemyConfig;
            _target = target.transform;
            _enemyRigidbody = enemyRigidbody2D;
        }

        public void FixedUpdate()
        {
            _movementVector = ((Vector2) _target.position - _enemyRigidbody.position).normalized 
                              * _enemyConfig.MovementSpeed * Time.fixedDeltaTime;
            _enemyRigidbody.velocity = _movementVector;
        }
    }
}