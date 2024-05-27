using Player.Model;
using UnityEngine;

namespace Player.Presenter
{

    public class PlayerMovePresenter
    {
        private readonly PlayerMoverModel _playerMoverModel;
        public PlayerMovePresenter()
        {
            _playerMoverModel = new PlayerMoverModel();
        }

        public void MovePlayer(Rigidbody2D playerRigidbody, Vector2 moveDirection)
        {
            moveDirection *= _playerMoverModel.MovementSpeed;
            playerRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }

}
