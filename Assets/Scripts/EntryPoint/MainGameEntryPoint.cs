using System;
using Player;
using UnityEngine;
using Utils.EventBus;
using Utils.ServiceLocator;

namespace EntryPoint
{

    public class MainGameEntryPoint : MonoBehaviour
    {
        private EventBus _eventBus;

        private void Awake()
        {
            CreateServices();
            RegisterServices();
        }

        private void CreateServices()
        {
            _eventBus = new EventBus();
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(_eventBus);
        }
    }

}