using System;
using Player;
using UnityEngine;
using Utils.EventBus;
using Utils.EventBus.Signals;
using Utils.ServiceLocator;

namespace Zone
{

    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _fireGap = 0.2f;
        
        private float _timer = 0f;
        private void OnTriggerStay2D(Collider2D col)
        {
            Debug.Log("OnTriggerStay2D");
            if (col.TryGetComponent(out PlayerView playerView) && _timer >= _fireGap)
            {
                Debug.Log("Applied damage");
                ServiceLocator.Instance.Get<EventBus>().Invoke(new PlayerEnteredFireZoneSignal(_damage));
                _timer = 0;
            }

            _timer += Time.deltaTime;
        }
    }

}