using Models;
using Models.Health;
using TMPro;
using UnityEngine;
using Zenject;

namespace Views.Healthbar
{
    public class PlayerHealthbar : HealthbarView
    {
        [SerializeField] private TMP_Text _healthText;

        [Inject]
        public override void Initialize(IHealthModel playerHealthModel)
        {
            base.Initialize(playerHealthModel);
        }

        public override void ChangeVisual(float value)
        {
            base.ChangeVisual(value);
            _healthText.text = value.ToString();
        }
    }
}