using UnityEngine;
using Zenject;

public class AssetProvider : IAssetProvider
{
    private readonly IInstantiator _instantiator;
    public AssetProvider(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }
    public GameObject Instantiate(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        return _instantiator.InstantiatePrefab(prefab);
    }
    public GameObject Instantiate(string path, Vector3 at)
    {
        var prefab = Resources.Load<GameObject>(path);
        return _instantiator.InstantiatePrefab(prefab , at,Quaternion.identity,null);
    }
}
