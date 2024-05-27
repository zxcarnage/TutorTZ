using System;
using Player.Model;
using Visitor;
using Zone;

namespace Player.Presenter
{
    public class PlayerStatsPresenter : IDisposable
    {
        private readonly PlayerStatsModel _model;

        public event Action<float> PlayerHealthChanged;

        public PlayerStatsPresenter()
        {
            _model = new PlayerStatsModel(100f);
        }

        public void DecreasePlayerHealth(float damage)
        {
            var targetHealth = _model.Health - damage;
            HealthChanged(targetHealth);
            _model.SetHealth(targetHealth <= 0 ? 0 : targetHealth);
        }

        private void IncreasePlayerHealth(float value)
        {
            var targetHealth = _model.Health + value >= 100f ? 100f : _model.Health + value;
            _model.SetHealth(targetHealth);
            HealthChanged(targetHealth);
        }

        public void RegenHp(HealthRegenPowerUp powerUp)
        {
            IncreasePlayerHealth(powerUp.HealthRegen);
        }

        private void HealthChanged(float value)
        {
            PlayerHealthChanged?.Invoke(value);
        }

        public void Dispose()
        {
            
        }
    }
}