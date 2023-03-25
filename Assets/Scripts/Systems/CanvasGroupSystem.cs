using UnityEngine;

namespace Systems
{
    public class CanvasGroupSystem : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private bool _canvasVisible;
        private bool _fadeIn;
        private bool _fadeOut;

        private void Update()
        {
            FadeIn(_fadeIn);
            FadeOut(_fadeOut);
        }


        public void MenuGame()
        {
            if (!_canvasVisible)
            {
                _fadeIn = true;
                _canvasVisible = true;
                
            }
            else
            {
                _fadeOut = true;
                _canvasVisible = false;
            }
            
        }

        private void FadeIn(bool fadeIn)
        {
            if (fadeIn)
            {
                if (_canvasGroup.alpha < 1)
                {
                    _canvasGroup.alpha += Time.deltaTime;
                    if (_canvasGroup.alpha >= 1)
                    {
                        _fadeIn = false;
                    }
                }
            }
        }

        private void FadeOut(bool fadeOut)
        {
            if (fadeOut)
            {
                if (_canvasGroup.alpha > 0)
                {
                    _canvasGroup.alpha -= Time.deltaTime;
                    if (_canvasGroup.alpha <= 0)
                    {
                        _fadeOut = false;
                    }
                }
            }
        }
    } 
}