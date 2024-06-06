using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Service
{
    public class InputService : MonoBehaviour , IInputService
    {
        public Vector2 MoveInput { get; private set; }
        public bool AttackClick { get; private set; }
        private PlayerController _playerController;
        private void Awake()
        {
            _playerController = new PlayerController();

            _playerController.Character.Move.performed += context => MoveInput = context.ReadValue<Vector2>();
            _playerController.Character.Move.canceled += context => MoveInput = Vector2.zero;

            _playerController.Character.Attack.performed += context => AttackClick = true;
            _playerController.Character.Attack.canceled += context => AttackClick = false;
        }
        private void OnEnable() =>
            _playerController.Enable();
        private void OnDisable() =>
            _playerController.Enable();
    }
}