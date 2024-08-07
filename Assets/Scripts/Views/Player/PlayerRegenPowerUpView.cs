﻿using Models.Player;
using Presenters.Player;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    public class PlayerRegenPowerUpView : MonoBehaviour
    {
        private PlayerRegenPresenter _presenter;
        
        [Inject]
        public void Initialize(RegenConfig regenConfig, HealthModel healthModel)
        {
            _presenter = new PlayerRegenPresenter(regenConfig, healthModel);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && _presenter.Enabled == false)
                _presenter.Regenerate();
        }

    }
}