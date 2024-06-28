using System;
using Models.Player;
using UnityEngine;

namespace Views.Entity
{
    [RequireComponent(typeof(Transform))]
    public class EntityView : MonoBehaviour
    {
        public void Initialize(float maxHealth)
        {
            EntityHealthModel = new HealthModel(maxHealth);
        }

        private void Awake()
        {
            EntityTransform = GetComponent<Transform>();
        }

        public HealthModel EntityHealthModel { get; private set; }

        public Transform EntityTransform { get; private set; }
    }
}