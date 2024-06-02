using UnityEngine;

namespace Assets.CodeBase.Logic.Enemy
{
    public class State
    {
        protected EnemyBase _enemyBase;
        protected StateMachine _stateMachine;

        protected string _animBollName;
        protected bool _triggerCalled;
        protected float _stateTimer;
        public State(EnemyBase enemyBase, StateMachine stateMachine, string animBollName)
        {
            _enemyBase = enemyBase;
            _stateMachine = stateMachine;
            _animBollName = animBollName;
        }
        public virtual void Enter()
        {
            _triggerCalled = false;
        }
        public virtual void Update()
        {
            _stateTimer -= Time.deltaTime;
        }
        public virtual void Exit()
        {

        }
    }
}