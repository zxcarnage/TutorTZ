using System.Collections;
using Models.Player;
using UnityEngine;
using Utils;
using Views;

namespace Presenters.TriggerZone
{

    public class TriggerZonePresenter
    {
        private Coroutine _coroutine;
        private readonly float _damage;
        private readonly float _damageDelay;
        private readonly HealthModel _healthModel;

        public TriggerZonePresenter(HealthModel healthModel, float damage, float damageDelay)
        {
            _healthModel = healthModel;
            _damage = damage;
            _damageDelay = damageDelay;
        }

        public void Enable()
        {
            _coroutine = Coroutines.StartRoutine(DealDamageRoutine());
        }

        private IEnumerator DealDamageRoutine()
        {
            while (true)
            {
                _healthModel.Decrease(_damage);
                yield return new WaitForSeconds(_damageDelay);
            }
        }
        

        public void Disable()
        {
            Coroutines.StopRoutine(_coroutine);
            _coroutine = null;
        }
    }
}