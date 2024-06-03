using UnityEngine;

namespace Assets.CodeBase.Logic.Enemy
{
    public class MoveState_Melee : State
    {
        private EnemyMelee _enemy;
        private Vector3 _destination;
        public MoveState_Melee(EnemyBase enemyBase, StateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemyMelee;
        }

        public override void Enter()
        {
            base.Enter();
            _enemy.Agent.speed = _enemy._moveSpeed;
            _destination = _enemy.GetPatrolDestination();
            _enemy.Agent.SetDestination(_destination);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (_enemy.Agent.remainingDistance <= _enemy.Agent.stoppingDistance)
            {
                _stateMachine.ChangeState(_enemy.IdleState);
            }
        }
    }
}