using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public interface IPlayerFactory
    {
        GameObject CreateHero(GameObject at);
    }
}