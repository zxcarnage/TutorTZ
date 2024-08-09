using System;
using UnityEngine;
using Views.Player;

namespace Views.Enemy.EnemyStateMachine.Transition
{
    public class MoveTransitionView : TransitionView
    {
        private void OnEnable()
        {
            NeedTransit = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMoveView player))
                NeedTransit = true;
        }
    }
}