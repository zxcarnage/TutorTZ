using TMPro;
using UnityEngine;

namespace Views.Healthbar
{
    public class HealthbarWithTextView : HealthbarView
    {
        [SerializeField] private TMP_Text _healthText;
        public override void ChangeVisual(float value)
        {
            base.ChangeVisual(value);
            _healthText.text = value.ToString();
        }
    }
}