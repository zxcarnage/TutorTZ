﻿using System;
using ScriptableObjects;
using UnityEngine;

namespace Models.Health
{

    public abstract class HealthModel : IHealthModel
    {
        private const string InvalidValueException = "Invalid health change value";
        private float _health;

        public HealthModel(PlayerConfig playerConfig)
        {
            if (playerConfig.MaxHealth <= 0)
                throw new ArgumentOutOfRangeException();
            
            MaxHealth = playerConfig.MaxHealth;
            _health = MaxHealth;
        }

        public float MaxHealth { get; private set; }
        
        public event Action<float> Changed;

        public void Decrease(float value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(InvalidValueException);
                    
            _health -= value;
            ClampHealth();
            Debug.Log(_health);
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