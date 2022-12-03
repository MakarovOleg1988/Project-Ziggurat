using UnityEngine;

namespace Ziggurat
{
    [RequireComponent(typeof(SwordComponent))]
    public class TriggerManager : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponents<SwordComponent>() == null) return;
            {
                EventManager.SendSetDamage();
                EventManager.SnowHPBar();
            }
        }
    }
}
