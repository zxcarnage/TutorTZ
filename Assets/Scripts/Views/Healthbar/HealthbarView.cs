using Models.Player;
using Presenters.Healthbar;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace Views.Healthbar
{
    public class HealthbarView : MonoBehaviour
    {
        [SerializeField] private Slider _healtbarSlider;

        private HealthbarPresenter _presenter;

        [Inject]
        public void Initialize(HealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant(healthModel);
            _presenter = new HealthbarPresenter(healthModel, this);
            
            _healtbarSlider.maxValue = healthModel.MaxHealth;
            _healtbarSlider.value = healthModel.MaxHealth;
        }

        public void OnEnable()
        {
            _presenter.Enable();
        }

        public void OnDisable()
        {
            _presenter.Disable();
        }

        public virtual void ChangeVisual(float value )
        {
            _healtbarSlider.value = value;
        }
    }
}