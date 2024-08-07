using Models;
using Models.Health;
using Utils;
using Views.Healthbar;

namespace Presenters.Healthbar
{

    public class HealthbarPresenter
    {
        private readonly IHealthModel _model;
        private readonly HealthbarView _view;
        
        public HealthbarPresenter(IHealthModel model, HealthbarView view)
        {
            InvariantChecker.CheckObjectInvariant(model, view);
            
            _model = model;
            _view = view;
        }
        

        public void Enable()
        {
            _model.Changed += ChangeHealthbarValue;
        }

        public void Disable()
        {
            _model.Changed -= ChangeHealthbarValue;
        }

        private void ChangeHealthbarValue(float value)
        {
            _view.ChangeVisual(value);
        }
        
    }

}