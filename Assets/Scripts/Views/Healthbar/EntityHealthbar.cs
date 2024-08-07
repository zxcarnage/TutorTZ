using Models;
using Zenject;

namespace Views.Healthbar
{

    public class EntityHealthbar : HealthbarView
    {
        [Inject]
        public override void Initialize(IHealthModel healthModel)
        {
            base.Initialize(healthModel);
        }
    }

}