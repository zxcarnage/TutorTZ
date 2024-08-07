using Models.Player;
using Utils;


namespace Presenters.Damageable
{
    public class DamageablePresenter
    {
        private HealthModel _healthModel;
        
        public DamageablePresenter(HealthModel healthModel)
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