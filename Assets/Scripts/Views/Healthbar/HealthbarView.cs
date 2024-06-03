using Models.Player;
using Presenters.Healthbar;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Views.Healthbar
{
    public class HealthbarView : MonoBehaviour
    {
        [SerializeField] private Slider _healtbarSlider;

        private HealthbarPresenter _presenter;

        public void Initialize(HealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant(healthModel);
            _presenter = new HealthbarPresenter(healthModel, this);
            
            _healtbarSlider.maxValue = healthModel.MaxHealth;
            _healtbarSlider.value = healthModel.MaxHealth;
        }

        public void Enable()
        {
            _presenter.Enable();
        }

        public void Disable()
        {
            _presenter.Disable();
        }

        public virtual void ChangeVisual(float value )
        {
            _healtbarSlider.value = value;
        }
    }
}