using System;

namespace Models.Player
{
    public class HealthModel
    {
        private const string InvalidValueException = "Invalid health change value";
        public const float MaxHealth = 100f; //Предполагается что не будет изменяться

        public HealthModel()
        {
            Health = MaxHealth;
        }

        public float Health { get; private set; }
        public event Action<float> Changed;

        public void Decrease(float value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(InvalidValueException);
            
            if (Health - value < 0)
                Health = 0;
            else
                Health -= value;
            Changed?.Invoke(Health);
        }

        public void Increase(float value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(InvalidValueException);
            
            if (Health + value >= MaxHealth)
                Health = MaxHealth;
            else
                Health += value;
            Changed?.Invoke(Health);
        }
        
        //Increase и Decrease очень похожи друг на друга, спросить как можно исправить, дублируется код как-будто
    }
}