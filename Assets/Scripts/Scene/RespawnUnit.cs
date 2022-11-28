using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class RespawnUnit : MonoBehaviour
    {
        [SerializeField] public Transform[] _PointRespawn;
        [SerializeField] public GameObject[] _knigth;
        public RespawnGate _respawnGate;
        [SerializeField] private float _timebetweenspawn;

        private void Update()
        {
            SpawnKnigth(_knigth);
        }

        public void SpawnKnigth(GameObject[] _knigth)
        {
            switch (_respawnGate)
            {
                case RespawnGate.Red:
                    {
                        if (_timebetweenspawn <= 0)
                        {
                            for (int i = 0; i < _knigth.Length; i++)
                            {
                                Instantiate(_knigth[i], _PointRespawn[0].position, Quaternion.identity);
                                _knigth[i].SetActive(true);
                                _timebetweenspawn = 5f;
                            }
                        }
                        else _timebetweenspawn -= Time.deltaTime;
                    }; break;
                case RespawnGate.Green:
                    {
                        if (_timebetweenspawn <= 0)
                        {
                            for (int i = 0; i < _knigth.Length; i++)
                            {
                                Instantiate(_knigth[i], _PointRespawn[1].position, Quaternion.identity);
                                _timebetweenspawn = 5f;
                            }
                        }
                        else _timebetweenspawn -= Time.deltaTime;
                    }; break;
                case RespawnGate.Blue:
                    {
                        if (_timebetweenspawn <= 0)
                        {
                            for (int i = 0; i < _knigth.Length; i++)
                            {
                                Instantiate(_knigth[i], _PointRespawn[2].position, Quaternion.identity);
                                _timebetweenspawn = 5f;
                            }
                        }
                        else _timebetweenspawn -= Time.deltaTime;
                    }; break;
            }
        }
    }
}
