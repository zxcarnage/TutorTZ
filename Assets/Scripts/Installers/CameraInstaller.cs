using Presenters.Camera;
using ScriptableObject;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraConfig _cameraConfig;
        public override void InstallBindings()
        {
            Container.Bind<CameraConfig>().FromScriptableObject(_cameraConfig).AsSingle().NonLazy();
        }
    }

}