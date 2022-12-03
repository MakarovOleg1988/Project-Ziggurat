using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ziggurat
{
    public class KnigthComponent : MonoBehaviour
    {
        protected NavMeshAgent _agent;
        [SerializeField] public Transform[] _knigth;
        [SerializeField] protected List<Transform> _targets;
        public KnigthType knigthType;
       
        protected float _attackRange = 4f;
        protected string result;
        [SerializeField] public int _health;
        [SerializeField] protected float _Attackdistance;
        protected float valueX;
        protected float _chaseRange = 20f;
        protected int _id;
    }
}
