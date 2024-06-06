using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        public IInstantiator _instantiator;

        [Inject]
        public void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        private void Start()
        {
            SceneLoader sceneLoader = new SceneLoader(this);
            IAssetProvider assetProvider = new AssetProvider(_instantiator);
            //IPlayerFactory playerFactory = new PlayerFactory(assetProvider);
            LoadLevel loadLevel = new LoadLevel(sceneLoader/* playerFactory*/);
            loadLevel.Enter("Level_1_");
            DontDestroyOnLoad(this);
        }
    }
}