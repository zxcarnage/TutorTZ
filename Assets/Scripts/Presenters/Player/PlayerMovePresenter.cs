using System;
using ScriptableObject;
using UnityEngine;
using Utils;

namespace Presenters.Player
{
    public class PlayerMovePresenter
    {
        private readonly float _movementSpeed;
        private readonly Rigidbody2D _rigidbody2D;
        public PlayerMovePresenter(PlayerConfig config, Rigidbody2D playerRigidbody)
        {
            InvariantChecker.CheckObjectInvariant(config);
            if (config.Speed <= 0)
                throw new ArgumentOutOfRangeException();
            
            _movementSpeed = config.Speed;
            _rigidbody2D = playerRigidbody;
        }

        public void MovePlayer(Vector2 moveDirection)
        {
            moveDirection *= _movementSpeed;
            _rigidbody2D.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }

}
