using UnityEngine;

namespace Assets.CodeBase.Service
{
    public interface IInputService
    {
        Vector2 MoveInput { get; }
        bool AttackClick { get; }
    }
}