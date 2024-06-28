using System;
using Presenters.Player;
using ScriptableObject;
using UnityEngine;
using Views.Entity;
using Views.Healthbar;
using Views.Player;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private RegenConfig _regenConfig;
        [SerializeField] private PlayerConfig _playerConfig;

        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private PlayerMoveView _player;

        public override void InstallBindings()
        {
            Container.Bind<RegenConfig>().FromScriptableObject(_regenConfig).AsSingle().NonLazy();
            Container.Bind<PlayerConfig>().FromScriptableObject(_playerConfig).AsSingle().NonLazy();
            var playerMoveView = Container.InstantiatePrefabForComponent<PlayerMoveView>(_player, _playerSpawnPoint);
            Container.Bind<PlayerMoveView>().FromInstance(playerMoveView).AsSingle().NonLazy();
        }
    }
}