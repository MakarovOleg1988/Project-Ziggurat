using System;
using UnityEngine;

namespace Ziggurat
{
    public class EventManager : MonoBehaviour
    {
        public static event Action _onSetDamage;
        public static event Action _onShowHPBar;

        public static void SendSetDamage()
        {
            _onSetDamage?.Invoke();
        }

        public static void SnowHPBar()
        {
            _onShowHPBar?.Invoke();
        }
    }
}
