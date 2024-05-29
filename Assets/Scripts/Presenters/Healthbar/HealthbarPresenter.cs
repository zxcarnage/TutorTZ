using System.Collections.Generic;
using Models.Player;
using Views.Healthbar;

namespace Presenters.Healthbar
{

    public class HealthbarPresenter
    {
        private readonly HealthModel _healthModel;
        private readonly List<HealthbarView> _views;
        
        public HealthbarPresenter(HealthModel model, List<HealthbarView> views)
        {
            _healthModel = model;
            _views = views;
        }

        public void Enable()
        {
            _healthModel.Changed += ChangeHealthbarValue;
        }

        public void Disable()
        {
            _healthModel.Changed -= ChangeHealthbarValue;
        }

        private void ChangeHealthbarValue(float value)
        {
            foreach (var view in _views)
            {
                view.ChangeVisual(value);
            }
        }
        
    }

}