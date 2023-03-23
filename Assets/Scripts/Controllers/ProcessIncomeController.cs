using UnityEngine;
using Views;

namespace Controllers
{
    public class ProcessIncomeController : MonoBehaviour
    {
        private float _currentTime, _timeDelay;
        private ProcessIncomeView _view;
 
        public void Initialize(float timeDelay, ProcessIncomeView view)
        {
            _timeDelay = timeDelay;
            _view = view;
            _view.DisplayView(_currentTime);
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
 
            _view.DisplayView(ratio);
        }
    }
}