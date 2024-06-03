using Presenters.TriggerZone;
using UnityEngine;
using Utils;
using Views.Damageable;

namespace Views
{
    public class TriggerZoneView : MonoBehaviour
    {
        private TriggerZonePresenter _presenter;
        public void Initialize(TriggerZonePresenter presenter)
        {
            InvariantChecker.CheckObjectInvariant(presenter);
            _presenter = presenter;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out DamageableView damageable))
            {
                _presenter.TryStartDamage(damageable);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out DamageableView damageable))
            {
                _presenter.TryStopDamage(damageable);
            }
        }
    }
}