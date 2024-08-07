using Presenters.Player;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    public class PlayerMoveView : MonoBehaviour
    {
        private PlayerMovePresenter _presenter;

        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        [Inject]
        public void Initialize(Rigidbody2D playerRigidbody, PlayerConfig playerConfig)
        {
            _presenter = new PlayerMovePresenter(playerRigidbody,playerConfig);
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