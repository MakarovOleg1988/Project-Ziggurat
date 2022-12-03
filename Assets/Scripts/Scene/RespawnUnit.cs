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

        [SerializeField] private float _timebetweenspawnRed;
        [SerializeField] private float _timebetweenspawnGreen;
        [SerializeField] private float _timebetweenspawnBlue;
        public bool _stopRespawn = false;

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
                        if (_timebetweenspawnRed <= 0 && _stopRespawn == false)
                        {
                            Instantiate(_knigth[0], _PointRespawn[0].position, Quaternion.identity);
                            _knigth[0].SetActive(true);
                           
                            _timebetweenspawnRed = 10f;
                        }
                        else _timebetweenspawnRed -= Time.deltaTime;
                    }; break;
                case RespawnGate.Green:
                    {
                        if (_timebetweenspawnGreen <= 0 && _stopRespawn == false)
                        {
                            Instantiate(_knigth[1], _PointRespawn[1].position, Quaternion.identity);
                            _knigth[1].SetActive(true);
                            _timebetweenspawnGreen = 10f;
                        }
                        else _timebetweenspawnGreen -= Time.deltaTime;
                    }; break;
                case RespawnGate.Blue:
                    {
                        if (_timebetweenspawnBlue <= 0 && _stopRespawn == false)
                        {
                            Instantiate(_knigth[2], _PointRespawn[2].position, Quaternion.identity);
                            _knigth[2].SetActive(true);
                            _timebetweenspawnBlue = 10f;
                        }
                        else _timebetweenspawnBlue -= Time.deltaTime;
                    }; break;
            }
        }
    }
}
