using UnityEngine;

namespace Assets.CodeBase.Logic.Enemy
{
    public class MoveState_Melee : State
    {
        private EnemyMelee _enemy;
        public MoveState_Melee(EnemyBase enemyBase, StateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemyMelee;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            Debug.Log("+");
        }
    }
}