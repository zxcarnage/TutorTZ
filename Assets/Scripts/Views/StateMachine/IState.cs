namespace Views.StateMachine
{
    public interface IState
    {
        public void Enter();
        public void Update();
    
        public void FixedUpdate();
    
        public void ChangeState(StateMachineView stateMachineView);

        public void Exit();
    }
}