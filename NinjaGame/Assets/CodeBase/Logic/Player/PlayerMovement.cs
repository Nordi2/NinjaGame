using Assets.CodeBase.Logic.Enemy;
using Assets.CodeBase.Service;
using System;
using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        public InputService _inputService;//изменить 
        private CharacterController _characterController;
        private PlayerAnimation _animation;
        private TriggerObserver _triggerObserver;

        private float _verticalVelocity;
        private Vector3 _moveDirection;
        private bool _triggreCalled;
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animation = GetComponentInChildren<PlayerAnimation>();
            _triggerObserver = GetComponent<TriggerObserver>();
        }
        private void Start()
        {
            _triggerObserver.TriggerStay += OnTriggerStay;
        }

        private void Update()
        {
            if (!_triggreCalled)
            {
                ApplyMovement();
                AnimationController();
            }
        }
        private void AnimationController()
        {
            float xVelocity = Vector3.Dot(_moveDirection, transform.right);
            float zVelocity = Vector3.Dot(_moveDirection, transform.forward);

            _animation.Move(xVelocity, zVelocity);
        }

        private void ApplyMovement()
        {
            _moveDirection = new Vector3(_inputService._moveInput.x, 0, _inputService._moveInput.y);
            ApplyGravity();
            _moveDirection.Normalize();
            if (_moveDirection.magnitude > 0)
            {
                _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);
            }
        }
        private void ApplyGravity()
        {
            if (!_characterController.isGrounded)
            {
                _verticalVelocity -= Constants.GravityScale * Time.deltaTime;
                _moveDirection.y = _verticalVelocity;
            }
            else
            {
                _moveDirection.y -= 0.5f;
            }
        }
        private void OnTriggerStay(Collider obj)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _animation.Attack();
            }
        }
        public void AnimationTriggerOn() => _triggreCalled = true;
        public void AnimatiomTriggerOff() => _triggreCalled = false;
    }
}