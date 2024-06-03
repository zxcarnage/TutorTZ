using System;
using UnityEngine;
using Utils;

namespace Presenters.Player
{
    public class PlayerMovePresenter
    {
        private readonly float _movementSpeed;
        private readonly Rigidbody2D _rigidbody2D;
        public PlayerMovePresenter(Rigidbody2D rigidbody2D, float movementSpeed)
        {
            InvariantChecker.CheckObjectInvariant(rigidbody2D);
            if (movementSpeed <= 0)
                throw new ArgumentOutOfRangeException();
            
            _movementSpeed = movementSpeed;
            _rigidbody2D = rigidbody2D;
        }

        public void MovePlayer(Vector2 moveDirection)
        {
            moveDirection *= _movementSpeed;
            _rigidbody2D.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }

}
