using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBase : MonoBehaviour
    {
        public NavMeshAgent Agent { get; private set; }
        public Animator Animator { get; private set; }
        public StateMachine StateMachine { get; private set; }

        public float _moveSpeed;
        [Header("Idle Info")]
        public float _idleTime;
        [Header("Patrol Info")]
        [SerializeField] private Transform[] _patrolPoints;
        private int _currentPatrolIndex;
        protected virtual void Awake()
        {
            StateMachine = new StateMachine();
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponentInChildren<Animator>();
        }
        protected virtual void Start()
        {
            InitializePatrolPoints();
        }
        protected virtual void Update()
        {

        }
        public Vector3 GetPatrolDestination() 
        {
            Vector3 destination = _patrolPoints[_currentPatrolIndex].transform.position;

            _currentPatrolIndex++;
            if (_currentPatrolIndex >=_patrolPoints.Length)
            {
                _currentPatrolIndex = 0;
            }
            return destination;
        }
        private void InitializePatrolPoints()
        {
            foreach (Transform transform in _patrolPoints)
            {
                transform.parent = null;
            }
        }
    }
}