using TMPro;
using UnityEngine.UI;
using Utils.EventBus.Signals;

namespace UI.Healthbar
{

    public class HealthbarPresenter
    {
        private HealthbarModel _model;
        
        public HealthbarPresenter()
        {
            _model = new HealthbarModel();
            
        }

        public void ChangeHealthbarValue(PlayerHealthChangedSignal signal, Slider healthbarSlider, TMP_Text healthbarText)
        {
            _model.SetValue(signal.Value >= 0 ? signal.Value : 0);
            healthbarSlider.value = _model.Value / 100;
            if(healthbarText)
                healthbarText.text = ((int) _model.Value).ToString();
        }
        
    }

}