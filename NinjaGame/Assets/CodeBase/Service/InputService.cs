using UnityEngine;

namespace Assets.CodeBase.Service
{
    public class InputService : MonoBehaviour , IInputService
    {
        public Vector2 _moveInput { get; private set; }
        public bool _attackClick { get; private set; }
        private PlayerController _playerController;
        private void Awake()
        {
            _playerController = new PlayerController();

            _playerController.Character.Move.performed += context => _moveInput = context.ReadValue<Vector2>();
            _playerController.Character.Move.canceled += context => _moveInput = Vector2.zero;

            _playerController.Character.Attack.performed += context => _attackClick = true;
            _playerController.Character.Attack.canceled += context => _attackClick = false;
        }
        private void OnEnable() =>
            _playerController.Enable();
        private void OnDisable() =>
            _playerController.Enable();
    }
}