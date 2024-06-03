using Presenters.Player;
using UnityEngine;
using Utils;

namespace Views.Player
{
    public class PlayerRegenPowerUpView : MonoBehaviour
    {
        private PlayerRegenPresenter _presenter;
        
        public void Initialize(PlayerRegenPresenter presenter)
        {
            InvariantChecker.CheckObjectInvariant(presenter);
            _presenter = presenter;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && _presenter.Enabled == false)
                _presenter.Enable();
        }

    }
}