using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Models;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.Enemy.EnemyStateMachine.Transition;

namespace Presenters.Enemy.State
{
    public class AttackStatePresenter : StatePresenter
    {
        private readonly IHealthModel _playerHealthModel;
        private readonly EnemyConfig _config;
        private readonly Rigidbody2D _enemyRigidbody;

        private CancellationTokenSource _cancellationTokenSource;

        public AttackStatePresenter(IHealthModel playerHealthModel, EnemyConfig config, List<TransitionView> transitions, Rigidbody2D enemyRigidbody) : base(transitions)
        {
            InvariantChecker.CheckObjectInvariant(playerHealthModel, config, transitions, enemyRigidbody);

            _playerHealthModel = playerHealthModel;
            _config = config;
            _enemyRigidbody = enemyRigidbody;

        }

        public async UniTask Enter()
        {
            _enemyRigidbody.velocity = Vector2.zero;
            _cancellationTokenSource = new();
            await DamageTask(_cancellationTokenSource.Token);
        }

        private async UniTask DamageTask(CancellationToken token)
        {
            try
            {
                while (token.IsCancellationRequested == false)
                {
                    await UniTask.Delay((int) (_config.AttackDelay * 1000), cancellationToken: token);
                    _playerHealthModel.Decrease(_config.Damage);
                }
            }
            catch (OperationCanceledException)
            {
            }
            
        }

        public void Exit()
        {
            _cancellationTokenSource.Cancel();
        }
    }

}