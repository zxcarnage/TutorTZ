﻿using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObject;
using UnityEngine;
using Utils;
using Views.Damageable;

namespace Presenters.TriggerZone
{

    public class TriggerZonePresenter
    {
        private readonly float _damage;
        private readonly float _damageDelay;
        private readonly CoroutineService _coroutineService;
        private readonly WaitForSeconds _waitForDelayEnumerator;
        private readonly Dictionary<DamageableView, Coroutine> _damageableCoroutines;


        public TriggerZonePresenter(CoroutineService coroutineService,  TriggerZoneConfig config)
        {
            InvariantChecker.CheckObjectInvariant(coroutineService, config);
            _damage = config.Damage;
            _damageDelay = config.DamageDelay;
            
            if (_damage < 0 || _damageDelay <= 0)
                throw new ArgumentOutOfRangeException();
            
            _coroutineService = coroutineService;
            
            _waitForDelayEnumerator = new WaitForSeconds(_damageDelay);
            _damageableCoroutines = new Dictionary<DamageableView, Coroutine>();
        }

        public void TryStartDamage(DamageableView damageableView)
        {
            if (!_damageableCoroutines.ContainsKey(damageableView))
                StartDamage(damageableView);
            else
                Debug.LogWarning("Coroutine already exists!");
        }

        public void TryStopDamage(DamageableView damageableView)
        {
            if (_damageableCoroutines.ContainsKey(damageableView))
                StopDamage(damageableView);
            else
                Debug.LogWarning("Trying to stop nonexistent coroutine");
        }
        
        private void StartDamage(DamageableView damageableView)
        {
            _damageableCoroutines.Add(damageableView, _coroutineService.StartRoutine(DealDamageRoutine(damageableView)));
        }

        private void StopDamage(DamageableView damageableView)
        {
            _coroutineService.StopRoutine(_damageableCoroutines[damageableView]);
            _damageableCoroutines.Remove(damageableView);
        }
        
        private IEnumerator DealDamageRoutine(DamageableView damageableView)
        {
            while (true)
            {
                damageableView.DealDamage(_damage);
                yield return _waitForDelayEnumerator;
            }
        }
    }
}