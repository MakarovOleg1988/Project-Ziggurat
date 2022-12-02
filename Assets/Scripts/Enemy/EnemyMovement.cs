using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Ziggurat
{
    public class EnemyMovement : MonoBehaviour
    {
        NavMeshAgent _agent;
        [SerializeField] private Transform[] _knigth;
        [SerializeField] private List<Transform> _targets;
        public KnigthType knigthType;

        protected float valueX;
        private float _chaseRange = 20f;
        private int _id;

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

        private void Chase()
        {
            switch (knigthType)
            {
                case KnigthType.Red:
                    {
                        Movement();
                    }; break;
                case KnigthType.Green:
                    {
                        Movement();
                    }; break;
                case KnigthType.Blue:
                    {
                        Movement();
                    }; break;
            }
        }

        public void Movement()
        {
            float distance = Vector3.Distance(transform.position, _knigth[1].position);
            float distance2 = Vector3.Distance(transform.position, _knigth[2].position);
            if (distance < _chaseRange || distance2 < _chaseRange) _agent.SetDestination(_knigth[Random.Range(1, 2)].position);
        }
    }
}
