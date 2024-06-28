using Presenters.TriggerZone;
using ScriptableObject;
using UnityEngine;
using Utils;
using Views.Damageable;
using Zenject;

namespace Views
{
    public class TriggerZoneView : MonoBehaviour
    {
        private TriggerZonePresenter _presenter;
        
        [Inject]
        public void Initialize(CoroutineService coroutineService, TriggerZoneConfig config)
        {
            InvariantChecker.CheckObjectInvariant(coroutineService, config);
            _presenter = new TriggerZonePresenter(coroutineService,config);
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