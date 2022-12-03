using UnityEngine;
using UnityEngine.UI;

namespace Ziggurat
{
    public class UIController : MonoBehaviour
    {
        KnigthComponent _knigthComponent;
        [SerializeField] public Slider _sliderHPBar;

        private void Start()
        {
            EventManager._onShowHPBar += ShowHPBar;
        }

        private void ShowHPBar()
        {
            _sliderHPBar.value = _knigthComponent._health;
        }
    }
}


