using Models;
using Models.Health;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMoveView _player;
        [SerializeField] private Transform _playerSpawnPoint;


        public override void InstallBindings()
        {
            BindHealthModel();
            InstantiatePlayer();
            BindPlayerMoveView();
        }
        
        private void BindHealthModel()
        {
            Container.Bind<IHealthModel>()
                .To<PlayerHealthModel>()
                .AsSingle()
                .NonLazy();
        }

        private void InstantiatePlayer()
        {
            _player = Container.InstantiatePrefabForComponent<PlayerMoveView>
                (_player, _playerSpawnPoint.position, Quaternion.identity, null);
        }

        private void BindPlayerMoveView()
        {
            Container.Bind<PlayerMoveView>()
                .FromInstance(_player)
                .AsSingle()
                .NonLazy();
        }
    }
}