using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public interface IPlayerFactory
    {
        GameObject CreateHero(Vector3 at);
    }
}