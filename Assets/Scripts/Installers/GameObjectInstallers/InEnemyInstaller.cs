using System.Collections.Generic;
using Models;
using Models.Health;
using Presenters.Enemy.State;
using UnityEngine;
using Views.Enemy.EnemyStateMachine;
using Views.StateMachine;
using Zenject;

namespace Installers.GameObjectInstallers
{

    public class InEnemyInstaller: MonoInstaller <InEnemyInstaller>
    {
        [SerializeField] private EnemyStateMachineView _enemyStateMachineView;
        [SerializeField] private Rigidbody2D _enemyRigidbody;
        
        private List<IState> _enemyStates;
        
        public override void InstallBindings()
        {
            BindHealthModel();
            BindRigidbody();
            BindStateMachineView();
            CreateStates();
            BindStates();
        }

        private void BindRigidbody()
        {
            Container.Bind<Rigidbody2D>()
                .FromInstance(_enemyRigidbody)
                .AsSingle()
                .NonLazy();
        }

        private void BindStates()
        {
            Container.Bind<List<IState>>()
                .FromInstance(_enemyStates)
                .AsSingle()
                .NonLazy();
        }

        private void BindStateMachineView()
        {
            Container.Bind<StateMachineView>()
                .To<EnemyStateMachineView>()
                .FromInstance(_enemyStateMachineView)
                .AsSingle()
                .NonLazy();
        }

        private void CreateStates()
        {
            _enemyStates = new()
            {
                Container.Instantiate<MoveStatePresenter>(),
                Container.Instantiate<AttackStatePresenter>()
            };
        }

        private void BindHealthModel()
        {
            Container.Bind<IHealthModel>()
                .To<EnemyHealthModel>()
                .AsSingle()
                .NonLazy();
        }
    }

}