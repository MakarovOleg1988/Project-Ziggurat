using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class EnemyAttack : MonoBehaviour
    {
        private float _attackRange = 4f;
        [SerializeField] private int _health;
        [SerializeField] private float _Attackdistance;

        private void Start()
        {
            UnitEnvironment._animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            Transform _target = GameObject.FindGameObjectWithTag("Knigth").transform;
            _Attackdistance = Vector3.Distance(transform.position, _target.transform.position);

            if (_Attackdistance < _attackRange)
            {
                UnitEnvironment.Moving(0);
                UnitEnvironment.FastAttack();
            }
        }
    }
}