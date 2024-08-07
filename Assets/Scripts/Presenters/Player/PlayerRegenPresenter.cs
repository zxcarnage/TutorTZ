using Cysharp.Threading.Tasks;
using Models;
using Models.Health;
using ScriptableObjects;
using Utils;

namespace Presenters.Player
{
    public class PlayerRegenPresenter
    {
        private readonly RegenConfig _regenConfig;
        private readonly IHealthModel _healthModel;
        private readonly int _targetDelay;
        
        
        private float _timer;

        public PlayerRegenPresenter(RegenConfig regenConfig, IHealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant(regenConfig, healthModel);
            
            _regenConfig = regenConfig;
            _healthModel = healthModel;
            _targetDelay = (int) (_regenConfig.RegenDelay * 1000);
        }

        public bool Enabled { get; private set; }

        public void Regenerate()
        {
            Enabled = true;
            RegenRoutine().Forget();
        }

        private async UniTaskVoid RegenRoutine()
        {
            while (_timer <= _regenConfig.RegenDuration)
            {
                _healthModel.Increase(_regenConfig.RegenValue);
                await UniTask.Delay(_targetDelay) ;
                _timer += _regenConfig.RegenDelay;
            }

            _timer = 0f;
            Enabled = false;
        }
    }
}