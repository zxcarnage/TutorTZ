using System;
using ScriptableObjects;
using UnityEngine;

namespace Models.Health
{
    public class PlayerHealthModel : HealthModel
    {
        public PlayerHealthModel(PlayerConfig playerConfig) : base(playerConfig)
        {
        }
    }
}