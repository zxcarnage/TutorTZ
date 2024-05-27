using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Interfaces;
using Player.Model;
using Unity.VisualScripting;
using UnityEngine;
using Utils.EventBus.Signals;
using Utils.ServiceLocator;
using Visitor;
using EventBus = Utils.EventBus.EventBus;

namespace Player.Presenter
{
    public class PlayerStatsPresenter : IDisposable
    {
        private PlayerStatsModel _model;

        public PlayerStatsPresenter()
        {
            _model = new PlayerStatsModel(100f);
            ServiceLocator.Instance.Get<EventBus>().Subscribe<PlayerEnteredFireZoneSignal>(DecreasePlayerHealth);
        }

        private void DecreasePlayerHealth(PlayerEnteredFireZoneSignal signal)
        {
            var targetHealth = _model.Health - signal.Damage;
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
            ServiceLocator.Instance.Get<EventBus>().Invoke(new PlayerHealthChangedSignal(value));
        }

        public void Dispose()
        {
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<PlayerEnteredFireZoneSignal>(DecreasePlayerHealth);
        }
    }
}