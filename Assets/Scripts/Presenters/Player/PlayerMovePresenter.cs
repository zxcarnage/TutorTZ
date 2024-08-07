using System;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.Player
{
    public class PlayerMovePresenter
    {
        private readonly PlayerConfig _playerConfig;
        private readonly Rigidbody2D _rigidbody2D;
        public PlayerMovePresenter(Rigidbody2D rigidbody2D, PlayerConfig playerConfig)
        {
            InvariantChecker.CheckObjectInvariant(rigidbody2D, playerConfig);
            if (playerConfig.MovementSpeed <= 0)
                throw new ArgumentOutOfRangeException();
            
            _playerConfig = playerConfig;
            _rigidbody2D = rigidbody2D;
        }

        public void MovePlayer(Vector2 moveDirection)
        {
            moveDirection *= _playerConfig.MovementSpeed;
            _rigidbody2D.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }

}
