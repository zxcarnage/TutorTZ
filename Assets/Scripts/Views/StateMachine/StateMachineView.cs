using System;
using System.Collections.Generic;
using Presenters.StateMachine;
using UnityEngine;
using Zenject;

namespace Views.StateMachine
{

    public abstract class StateMachineView : MonoBehaviour
    {
        private StateMachinePresenter _presenter;

        [Inject]
        public virtual void Initialize(List<IState> states,StateMachineView stateMachineView)
        {
            _presenter = new StateMachinePresenter(states, stateMachineView);
        }

        private void Awake()
        {
            _presenter.StartMachine();
        }

        private void Update()
        {
            _presenter.Update();
        }

        private void FixedUpdate()
        {
            _presenter.FixedUpdate();
        }

        public void SetState(Type stateType)
        {
            _presenter.SetState(stateType);
        }
    }

}