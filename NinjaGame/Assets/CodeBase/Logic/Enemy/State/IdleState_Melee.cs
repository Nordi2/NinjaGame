using Assets.CodeBase.Logic.Enemy;

public class IdleState_Melee : State
{
    private EnemyMelee _enemy;
    public IdleState_Melee(EnemyBase enemyBase, StateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
    {
        _enemy = enemyBase as EnemyMelee;
    }

    public override void Enter()
    {
        base.Enter();
        _stateTimer = _enemyBase._idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (_stateTimer <= 0)
        {
            _stateMachine.ChangeState(_enemy.MoveState);
        }
    }
}
