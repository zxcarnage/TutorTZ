using System;
using Presenters.Player;
using ScriptableObject;
using UnityEngine;
using Utils;
using Zenject;

namespace Views.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMoveView : MonoBehaviour
    {
        private PlayerMovePresenter _presenter;

        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        [Inject]
        public void Initialize(PlayerConfig config)
        {
            InvariantChecker.CheckObjectInvariant(config);
            _presenter = new PlayerMovePresenter(config, GetComponent<Rigidbody2D>());
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