using Models.Player;
using Utils;
using Views.Healthbar;

namespace Presenters.Healthbar
{

    public class HealthbarPresenter
    {
        private readonly HealthModel _healthModel;
        private readonly HealthbarView _view;
        
        public HealthbarPresenter(HealthModel model, HealthbarView view)
        {
            InvariantChecker.CheckObjectInvariant(model, view);
            
            _healthModel = model;
            _view = view;
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
            _view.ChangeVisual(value);
        }
        
    }

}