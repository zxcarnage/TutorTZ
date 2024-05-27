using System;
using System.Collections;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Interfaces;
using Player;
using Player.Presenter;
using UnityEngine;

namespace Visitor
{
    [CreateAssetMenu(fileName = "Health Regen Power Up", menuName = "Power ups")]
    public class HealthRegenPowerUp : ScriptableObject, IVisitor
    {
        [SerializeField] private float _healthRegen = 3f;
        [SerializeField] private float _regenGap = 0.7f;
        [SerializeField] private float _duration = 5f;

        public float HealthRegen => _healthRegen;
        public float RegenGap => _regenGap;
        public float Duration => _duration;
        public void Visit(object o)
        {
            MethodInfo visitMethod = GetType().GetMethod("Visit", new Type[] {o.GetType()});
            if (visitMethod != null && visitMethod != GetType().GetMethod("Visit", new Type[] {typeof(object)}))
                visitMethod.Invoke(this, new object[] {o});
            else
                DefaultVisit(o);
        }

        private void DefaultVisit(object o)
        {
            Debug.Log("PowerUp.DefaultVisit");
        }

        public IEnumerator Visit(PlayerStatsPresenter playerStatsPresenter)
        {
            var passedTime = 0f;
            while (passedTime <= Duration)
            {
                playerStatsPresenter.RegenHp(this);
                yield return new WaitForSeconds(_regenGap);
                passedTime += _regenGap;
            }
        }
    }

}