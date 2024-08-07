using System.Collections.Generic;
using Views.StateMachine;
using Zenject;

namespace Views.Enemy.EnemyStateMachine
{

    public class EnemyStateMachineView : StateMachineView
    {
        [Inject]
        public override void Initialize(List<IState> states, StateMachineView stateMachineView)
        {
            base.Initialize(states, stateMachineView);
        }
    }

}