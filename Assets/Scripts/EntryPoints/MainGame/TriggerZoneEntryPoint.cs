using Presenters.TriggerZone;
using UnityEngine;
using Utils;
using Views;

namespace EntryPoints.MainGame
{
    public class TriggerZoneEntryPoint : MonoBehaviour
    {
        [SerializeField] private CoroutineService _coroutineService;
        
        [SerializeField] private TriggerZoneView _triggerView;
        
        [Space(10)] [Header("Trigger Zone Settings")] 
        [SerializeField] private float _triggerDamage;
        [SerializeField] private float _triggerDamageDelay;
        
        private TriggerZonePresenter _triggerZonePresenter;
        
        private void Awake()
        {
            CreatePresenters();
            InitializeViews();
        }
        
        private void CreatePresenters()
        {
            _triggerZonePresenter = new TriggerZonePresenter(_coroutineService, _triggerDamage, _triggerDamageDelay);
        }

        private void InitializeViews()
        {
            _triggerView.Initialize(_triggerZonePresenter);
        }
    }
}