using Cysharp.Threading.Tasks;
using Models.Player;
using ScriptableObjects;
using Utils;

namespace Presenters.Player
{
    public class PlayerRegenPresenter
    {
        private readonly RegenConfig _regenConfig;
        private readonly HealthModel _healthModel;
        
        
        private float _timer;
        private int _targetDelay;

        public PlayerRegenPresenter(RegenConfig regenConfig, HealthModel healthModel)
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