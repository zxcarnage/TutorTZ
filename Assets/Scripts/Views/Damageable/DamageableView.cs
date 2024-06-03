using System;
using UnityEngine;

namespace Views.Damageable
{
    public class DamageableView : MonoBehaviour
    {
        public event Action<float> TookDamage;
        public void DealDamage(float damage)
        {
            TookDamage?.Invoke(damage);
        }
    }
}