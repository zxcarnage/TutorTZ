using System;

namespace Models
{

    public interface IHealthModel
    {
        public void Increase(float value);
        public void Decrease(float value);
        
        public event Action<float> Changed;
        public float MaxHealth { get;}
    }

}