using UnityEngine;
using Views;

namespace Controllers
{
    public class ProcessIncomeController : MonoBehaviour
    {
        [SerializeField] private ProcessIncomeView _processIncomeView;
        
        private float _currentTime, _timeDelay;

        public void Initialize(float timeDelay)
        {
            _timeDelay = timeDelay;
            _processIncomeView.DisplayView(_currentTime);
        }
 
        private void Update()
        {
            _currentTime += Time.deltaTime;
 
            var ratio = _currentTime / _timeDelay;
            if (ratio >= 1)
            {
                ratio = 1;
                _currentTime = 0;
 
                //OnBarFilledEvent
            }
 
            _processIncomeView.DisplayView(ratio);
        }
    }
}