using Presenters.TriggerZone;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.Damageable;
using Zenject;

namespace Views.TriggerZone
{
    public class TriggerZoneView : MonoBehaviour
    {
        private TriggerZonePresenter _presenter;
        
        [Inject]
        public void Initialize(TriggerZoneConfig config)
        {
            _presenter = new TriggerZonePresenter(config);
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