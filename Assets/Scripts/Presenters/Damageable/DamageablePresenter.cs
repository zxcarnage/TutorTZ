using System;
using Models.Player;
using Utils;
using Views.Damageable;

namespace Presenters.Damageable
{
    public class DamageablePresenter : IDisposable
    {
        private readonly HealthModel _healthModel;
        private readonly DamageableView _view;

        public DamageablePresenter(DamageableView view, HealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant(view, healthModel);
            
            _healthModel = healthModel;
            _view = view;
            
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _view.TookDamage += DealDamage;
        }
        private void Unsubscribe()
        {
            _view.TookDamage -= DealDamage;
        }

        private void DealDamage(float damage)
        {
            _healthModel.Decrease(damage);
        }
    }
}