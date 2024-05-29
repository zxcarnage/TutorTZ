using System.Collections;
using Models.Player;
using ScriptableObject;
using UnityEngine;
using Utils;
using Views;

namespace Presenters.Player
{
    public class PlayerRegenPresenter
    {
        private HealthModel _healthModel;
        private RegenConfig _regenConfig;
        private Coroutine _coroutine;

        private float _timer = 0f;

        public PlayerRegenPresenter(RegenConfig regenConfig, HealthModel healthModel)
        {
            _healthModel = healthModel;
            _regenConfig = regenConfig;
        }

        public void Enable()
        {
            _coroutine ??= Coroutines.StartRoutine(RegenRoutine());
        }

        private IEnumerator RegenRoutine()
        {
            while (_timer <= _regenConfig.RegenDuration)
            {
                _healthModel.Increase(_regenConfig.RegenValue);
                yield return new WaitForSeconds(_regenConfig.RegenDelay);
                _timer += _regenConfig.RegenDelay;
            }

            _timer = 0f;
            _coroutine = null;
        }
    }
}