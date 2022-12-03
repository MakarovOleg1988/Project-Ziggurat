using UnityEngine;

namespace Ziggurat
{
    public class ButtonController : MonoBehaviour
    {
        RespawnUnit _respawnUnit;

        public void Start()
        {
            _respawnUnit._stopRespawn = true;
        }
    }
}