using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Healthbar
{
    public class HealthbarView : MonoBehaviour
    {
        [SerializeField] private Slider _healtbarSlider;
        [SerializeField] private TMP_Text _healthbarText;
        [SerializeField] private PlayerView _playerView;
        
        private HealthbarPresenter _presenter;

        private void Awake()
        {
            _presenter = new HealthbarPresenter();
        }

        private void OnEnable()
        {
            _playerView.HealthChanged += ChangeHealthbarValue;
        }
        

        private void ChangeHealthbarValue(float value)
        {
            _presenter.ChangeHealthbarValue(value, _healtbarSlider, _healthbarText);
        }

        private void OnDisable()
        {
            _playerView.HealthChanged -= ChangeHealthbarValue;
        }
    }
}