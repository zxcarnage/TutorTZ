using Models;
using Models.Health;
using Utils;


namespace Presenters.Damageable
{
    public class DamageablePresenter
    {
        private IHealthModel _healthModel;
        
        public DamageablePresenter(IHealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant(healthModel);
            _healthModel = healthModel;
        }
        
        public void DealDamage(float damage)
        {
            _healthModel.Decrease(damage);
        }
    }
}