using TMPro;
using UnityEngine.UI;

namespace UI.Healthbar
{

    public class HealthbarPresenter
    {
        private HealthbarModel _model;
        
        public HealthbarPresenter()
        {
            _model = new HealthbarModel();
            
        }

        public void ChangeHealthbarValue(float value, Slider healthbarSlider, TMP_Text healthbarText)
        {
            _model.SetValue(value >= 0 ? value : 0);
            healthbarSlider.value = _model.Value / 100;
            if(healthbarText)
                healthbarText.text = ((int) _model.Value).ToString();
        }
        
    }

}