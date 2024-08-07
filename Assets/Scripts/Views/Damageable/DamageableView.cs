using System;
using Models;
using Models.Health;
using Presenters.Damageable;
using UnityEngine;
using Zenject;

namespace Views.Damageable
{
    public class DamageableView : MonoBehaviour
    {
        private DamageablePresenter _presenter;

        [Inject]
        public void Initialize(IHealthModel healthModel)
        {
            _presenter = new DamageablePresenter(healthModel);
        }

        public void DealDamage(float damage)
        {
            _presenter.DealDamage(damage);
        }
    }
}