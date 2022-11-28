using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ziggurat
{
    public class EnemyMovement : UnitEnvironment
    {
        NavMeshAgent _agent;
        private int _id;
        public List<Transform> _targets;
        protected float valueX;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            MovementKnigth(_id);
            Moving(valueX);
        }

        void MovementKnigth(int _id)
        {
            if (_agent.transform.position == _agent.pathEndPosition) _id = Random.Range(0, _targets.Count);

            valueX = 1f;
            _agent.SetDestination(_targets[_id].position);
        }
    }
}
