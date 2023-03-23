using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ProcessIncomeView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void DisplayView(float currentTime)
        {
            _slider.value = currentTime;
        }
    }
}