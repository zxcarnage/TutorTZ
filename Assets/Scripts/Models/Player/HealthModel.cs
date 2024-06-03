using System;
using UnityEngine;

namespace Models.Player
{
    public class HealthModel
    {
        private const string InvalidValueException = "Invalid health change value";
        private float _health;

        public HealthModel(float maxHealth)
        {
            if (maxHealth <= 0)
                throw new ArgumentOutOfRangeException();
            
            _health = maxHealth;
            MaxHealth = maxHealth;
        }

        public float MaxHealth { get;}
        public event Action<float> Changed;

        public void Decrease(float value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(InvalidValueException);
                    
            _health -= value;
            ClampHealth();
            
            Changed?.Invoke(_health);
        }

        public void Increase(float value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(InvalidValueException);
            
            _health += value;
            ClampHealth();
            
            Changed?.Invoke(_health);
        }

        private void ClampHealth()
        {
            _health = Mathf.Clamp(_health, 0, MaxHealth);
        }
    }
}