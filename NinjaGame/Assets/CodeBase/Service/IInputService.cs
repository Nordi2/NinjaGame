using UnityEngine;

namespace Assets.CodeBase.Service
{
    public interface IInputService
    {
        Vector2 _moveInput { get; }
        bool _attackClick { get; }
    }
}