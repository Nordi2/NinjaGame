using Assets.CodeBase.Logic.Enemy;
using Assets.CodeBase.Service;
using System;
using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;

        private TriggerObserver _triggerObserver;
        private PlayerAnimation _animation;
        public event Action OnAttack;
        private void Awake()
        {
            _triggerObserver = GetComponent<TriggerObserver>();
            _animation = GetComponentInChildren<PlayerAnimation>();
        }
        private void OnEnable() =>
            _triggerObserver.TriggerStay += OnTriggerStay;
        private void OnDisable() =>
            _triggerObserver.TriggerStay -= OnTriggerStay;
        private void OnTriggerStay(Collider obj)
        {
            _animation.Attack(_inputService._attackClick);
            Vector3 offset = new Vector3(0, 0, -1);
            if (_inputService._attackClick)
            {
                transform.position = obj.GetComponentInParent<EnemyPosition>().transform.position + offset;
                OnAttack?.Invoke();
            }
        }
    }
}