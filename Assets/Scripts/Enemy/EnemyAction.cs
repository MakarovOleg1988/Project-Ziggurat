using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Ziggurat
{
    public class EnemyAction : KnigthComponent
    {
        UnitEnvironment _unitEnvironment;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            UnitEnvironment._animator = GetComponent<Animator>();
            EventManager._onSetDamage += SetDamage;

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
                        Attack();
                    }; break;
                case KnigthType.Green:
                    {
                        Movement();
                        Attack();
                    }; break;
                case KnigthType.Blue:
                    {
                        Movement();
                        Attack();
                    }; break;
            }
        }

        public void Movement()
        {
            float distance = Vector3.Distance(transform.position, _knigth[0].position);
            float distance2 = Vector3.Distance(transform.position, _knigth[1].position);
            if (distance < _chaseRange || distance2 < _chaseRange) _agent.SetDestination(_knigth[Random.Range(0, 1)].position);
        }

        private void Attack()
        {
            Transform _target = _knigth[Random.Range(0, 1)].transform;
            _Attackdistance = Vector3.Distance(transform.position, _target.transform.position);

            if (_Attackdistance < _attackRange)
            {
                UnitEnvironment.Moving(0);
                UnitEnvironment.FastAttack();
            }
        }

        private void SetDamage()
        {
            _health--;
            Debug.Log(_health);

            if (_health <= 0)
            {
                result = "Die";
                _unitEnvironment.Die(result);
                _unitEnvironment.AnimationEventEnd(result);

            }
        }
    }
}
