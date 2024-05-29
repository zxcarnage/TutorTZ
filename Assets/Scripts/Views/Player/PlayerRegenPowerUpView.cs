using Presenters.Player;
using UnityEngine;

namespace Views.Player
{
    public class PlayerRegenPowerUpView : MonoBehaviour
    {
        private PlayerRegenPresenter _presenter;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                _presenter.Enable();
        }

        public void Initialize(PlayerRegenPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}