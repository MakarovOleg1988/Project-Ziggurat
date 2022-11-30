using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System.Collections;

namespace Ziggurat
{
    public class EnemyMovement : UnitEnvironment
    {
        NavMeshAgent _agent;
        private int _id;
        private Transform enemy;
        [SerializeField] private List<Transform> _targets;
        protected float valueX;
        private float _attackRange = 2f;
        private float _chaseRange = 10f;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();

            StartCoroutine(MoveKnight(_id, enemy));
        }

        private Transform _enemy()
        {
            Transform enemy = GameObject.FindObjectOfType<Animator>().transform;
            return enemy;
        }

        private IEnumerator MoveKnight(int _id, Transform _enemy)
        {
            if (_agent.remainingDistance == _agent.stoppingDistance)
            {
                _id = Random.Range(0, _targets.Count);
                Moving(1);
                _agent.SetDestination(_targets[_id].position);
            }

            yield return new WaitForSeconds(2f);

            _agent.SetDestination(enemy.position);
            float distance = Vector3.Distance(_agent.transform.position, enemy.position);

            if (distance < _attackRange) Moving(0);
        }

    }
}
