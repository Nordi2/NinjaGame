using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [Header("Idle Info")]
        public float _idleTime;
        public NavMeshAgent Agent { get; private set; }
        public Animator Animator { get; private set; }
        public StateMachine StateMachine { get; private set; }

        protected virtual void Awake()
        {
            StateMachine = new StateMachine();
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponentInChildren<Animator>();
        }
        protected virtual void Start()
        {

        }
        protected virtual void Update()
        {

        }
    }
}