using Presenters.TriggerZone;
using UnityEngine;
using Views.Player;

namespace Views
{
    public class TriggerZoneView : MonoBehaviour
    {
        private TriggerZonePresenter _presenter;
        public void Initialize(TriggerZonePresenter presenter)
        {
            _presenter = presenter;
            //Спросить про то, как сделать кастомную корутину)
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMoveView player))
            {
                _presenter.Enable();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMoveView player))
            {
                _presenter.Disable();
            }
        }
    }
}