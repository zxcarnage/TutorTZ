using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.EventBus;
using Utils.EventBus.Signals;
using Utils.ServiceLocator;

namespace UI.Healthbar
{
    public class HealthbarView : MonoBehaviour
    {
        [SerializeField] private Slider _healtbarSlider;
        [SerializeField] private TMP_Text _healthbarText;
        
        private HealthbarPresenter _presenter;
        private EventBus _eventBus;

        private void Awake()
        {
            _presenter = new HealthbarPresenter();
        }

        private void OnEnable()
        {
            _eventBus = ServiceLocator.Instance.Get<EventBus>();
            _eventBus.Subscribe<PlayerHealthChangedSignal>(ChangeHealthbarValue);
        }

        private void ChangeHealthbarValue(PlayerHealthChangedSignal signal)
        {
            _presenter.ChangeHealthbarValue(signal, _healtbarSlider, _healthbarText);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<PlayerHealthChangedSignal>(ChangeHealthbarValue);
        }
    }
}