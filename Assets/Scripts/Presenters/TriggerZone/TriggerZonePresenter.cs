using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.Damageable;

namespace Presenters.TriggerZone
{
    public class TriggerZonePresenter
    {
        private readonly TriggerZoneConfig _config;
        private readonly Dictionary<DamageableView, KeyValuePair<CancellationTokenSource, UniTaskVoid>> _damageableTasks;
        private readonly int _secondsDelay;
        
        public TriggerZonePresenter(TriggerZoneConfig config)
        {
            InvariantChecker.CheckObjectInvariant(config);
            if (config.Damage < 0 || config.DamageDelay <= 0)
                throw new ArgumentOutOfRangeException();
            
            _damageableTasks = new ();
            _secondsDelay = (int) (_config.DamageDelay * 1000);
        }

        public void TryStartDamage(DamageableView damageableView)
        {
            if (_damageableTasks.ContainsKey(damageableView) == true)
                throw new ArgumentOutOfRangeException();
            StartDamage(damageableView);
        }

        public void TryStopDamage(DamageableView damageableView)
        {
            if (_damageableTasks.ContainsKey(damageableView) == false)
                throw new ArgumentOutOfRangeException();
            StopDamage(damageableView);
        }
        
        private void StartDamage(DamageableView damageableView)
        {
            var cts = new CancellationTokenSource();
            _damageableTasks.Add(damageableView, new(cts, DealDamageTask(damageableView, cts.Token)));

        }

        private void StopDamage(DamageableView damageableView)
        {
            _damageableTasks[damageableView].Key.Cancel();
            _damageableTasks.Remove(damageableView);
        }
        
        private async UniTaskVoid DealDamageTask(DamageableView damageableView, CancellationToken token)
        {
            try
            {
                while (true)
                {
                    await UniTask.Delay(_secondsDelay, cancellationToken: token);
                    token.ThrowIfCancellationRequested();
                    damageableView.DealDamage(_config.Damage);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Deal damage task cancelled");
            }
        }
    }
}