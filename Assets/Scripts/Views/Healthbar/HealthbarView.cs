using Models.Player;
using Presenters.Healthbar;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Healthbar
{
    public class HealthbarView : MonoBehaviour
    {
        [SerializeField] private Slider _healtbarSlider;

        private HealthbarPresenter _presenter;

        public void Initialize(HealthbarPresenter presenter)
        {
            _healtbarSlider.maxValue = HealthModel.MaxHealth;
            _healtbarSlider.value = HealthModel.MaxHealth;
            _presenter = presenter;
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