using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Views.StateMachine;

namespace Presenters.StateMachine
{
    public class StateMachinePresenter
    {
        private readonly List<IState> _states;
        private readonly StateMachineView _stateMachineView;
        private readonly Dictionary<Type, IState> _typeDictionary = new ();

        private IState _activeState;
        
        public StateMachinePresenter(List<IState> states, StateMachineView stateMachineView)
        {
            InvariantChecker.CheckObjectInvariant(states, stateMachineView);
            _states = states;
            _stateMachineView = stateMachineView;
            _states.ForEach((s) => _typeDictionary.Add(s.GetType(), s));
        }

        public void StartMachine()
        {
            SetState(_states[0].GetType());
        }
        
        public void SetState(Type stateType)
        {
            if(_activeState != null)
                _activeState.Exit();
            _activeState = _typeDictionary[stateType];
            _activeState.Enter();
        }

        public void Update()
        {
            _activeState.Update();
            _activeState.ChangeState(_stateMachineView);
        }

        public void FixedUpdate()
        {
            _activeState.FixedUpdate();
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            _activeState.OnTriggerEnter2D(col);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            _activeState.OnTriggerExit2D(other);
        }
    }

}