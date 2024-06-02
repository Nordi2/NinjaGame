using Assets.CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class LoadLevel
    {
        private SceneLoader _sceneLoader;
        private IPlayerFactory _playerFactory;
        public LoadLevel(SceneLoader sceneLoader, IPlayerFactory playerFactory)
        {
            _sceneLoader = sceneLoader;
            _playerFactory = playerFactory;
        }
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            GameObject hero = _playerFactory.CreateHero(GameObject.FindWithTag("SpawnPoint"));
        }
    }
}