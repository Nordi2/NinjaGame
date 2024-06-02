using Assets.CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            SceneLoader sceneLoader = new SceneLoader(this);
            IAssetProvider assetProvider = new AssetProvider();
            IPlayerFactory playerFactory = new PlayerFactory(assetProvider);
            LoadLevel loadLevel = new LoadLevel(sceneLoader, playerFactory);
            loadLevel.Enter("Level_1_");
            DontDestroyOnLoad(this);
        }
    }
}