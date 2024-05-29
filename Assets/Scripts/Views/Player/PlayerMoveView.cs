using Presenters.Player;
using UnityEngine;

namespace Views.Player
{
    public class PlayerMoveView : MonoBehaviour
    {
        private PlayerMovePresenter _presenter;
        
        private const string  Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public void Initialize(PlayerMovePresenter presenter)
        {
            _presenter = presenter;
        }

        private void FixedUpdate()
        {
            var horizontal = Input.GetAxis(Horizontal);
            var vertical = Input.GetAxis(Vertical);
            Vector2 moveDirection = new Vector2(horizontal, vertical);
            
            _presenter.MovePlayer(moveDirection);
        }
    }
}