using UnityEngine;

namespace Views.StateMachine
{
    public interface IState
    {
        public void Enter();
        public void Update();
    
        public void FixedUpdate();
    
        public void ChangeState(StateMachineView stateMachineView);
        public void OnTriggerEnter2D(Collider2D col);
        public void OnTriggerExit2D(Collider2D col);

        public void Exit();
    }
}