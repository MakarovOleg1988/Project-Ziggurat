using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Ziggurat
{
    public class EnemyMovement : MonoBehaviour
    {

        NavMeshAgent _agent;
        private int _id;
        [SerializeField] private Transform[] _knigth;
        [SerializeField] private List<Transform> _targets;
        protected float valueX;
        private float _chaseRange = 20f;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            UnitEnvironment._animator = GetComponent<Animator>();

            StartCoroutine(MoveKnight(_id));
        }

        private void Update()
        {
            Chase();
        }

        private IEnumerator MoveKnight(int _id)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _id = Random.Range(0, _targets.Count);
                UnitEnvironment.Moving(1);
                _agent.SetDestination(_targets[_id].position);
            }
            yield return new WaitForSeconds(2f);
        }

        public KnigthType knigthType;

        private void Chase()
        {
            switch (knigthType)
            {
                case KnigthType.Red:
                    {
                        float distance = Vector3.Distance(transform.position, _knigth[1].position);
                        float distance2 = Vector3.Distance(transform.position, _knigth[2].position);
                        if (distance < _chaseRange || distance2 < _chaseRange) _agent.SetDestination(_knigth[Random.Range(1, 2)].position);
                    }; break;
                case KnigthType.Green:
                    {
                        float distance = Vector3.Distance(transform.position, _knigth[0].position);
                        float distance2 = Vector3.Distance(transform.position, _knigth[2].position);
                        if (distance < _chaseRange || distance2 < _chaseRange) _agent.SetDestination(_knigth[Random.Range(0, 2)].position);
                    }; break;
                case KnigthType.Blue:
                    {
                        float distance = Vector3.Distance(transform.position, _knigth[0].position);
                        float distance2 = Vector3.Distance(transform.position, _knigth[1].position);
                        if (distance < _chaseRange || distance2 < _chaseRange) _agent.SetDestination(_knigth[Random.Range(0, 1)].position);
                    }; break;
            }
        }
    }
}
