using System.Collections;
using Models.Player;
using ScriptableObject;
using UnityEngine;
using Utils;

namespace Presenters.Player
{
    public class PlayerRegenPresenter
    {
        private readonly HealthModel _healthModel;
        private readonly RegenConfig _regenConfig;
        private readonly CoroutineService _coroutineService;
        private readonly WaitForSeconds _waitForDelay;
        
        private float _timer;

        public PlayerRegenPresenter(CoroutineService coroutineService, RegenConfig regenConfig, HealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant(coroutineService,regenConfig,healthModel);
            
            _healthModel = healthModel;
            _regenConfig = regenConfig;
            _coroutineService = coroutineService;

            _waitForDelay = new WaitForSeconds(_regenConfig.RegenDelay);
        }

        public bool Enabled { get; private set; }

        public void Enable()
        {
            Enabled = true;
            _coroutineService.StartRoutine(RegenRoutine());
        }

        private IEnumerator RegenRoutine()
        {
            while (_timer <= _regenConfig.RegenDuration)
            {
                _healthModel.Increase(_regenConfig.RegenValue);
                yield return _waitForDelay;
                _timer += _regenConfig.RegenDelay;
            }

            _timer = 0f;
            Enabled = false;
        }
    }
}