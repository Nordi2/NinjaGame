using Assets.CodeBase.Infrastructure.Factory;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private readonly IAssetProvider _assets;
    public PlayerFactory(IAssetProvider assets)
    {
        _assets = assets;
    }
    private GameObject HeroGameObject { get; set; }
    public GameObject CreateHero(GameObject at) 
    {
        HeroGameObject = InstantiateRegistered(AssetPath.HeroPath, at.transform.position);
        return HeroGameObject;
    }

    private GameObject InstantiateRegistered(string heroPath, Vector3 position)
    {
        GameObject gameObject = _assets.Instantiate(heroPath, position);
        return gameObject;
    }
}
