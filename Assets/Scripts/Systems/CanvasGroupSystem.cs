using DG.Tweening;
using UnityEngine;

namespace Systems
{
    public class CanvasGroupSystem : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private CanvasGroup _gameCanvasGroup;
        
        private bool _canvasVisible;
        private bool _fadeIn;
        private bool _fadeOut;
        
        public void MenuGame()
        {
            if (!_canvasVisible)
            {
                FadeIn();
                _canvasVisible = true;
                
            }
            else
            {
                FadeOut();
                _canvasVisible = false;
            }
            
        }

        private void FadeIn()
        {
            _canvasGroup.DOFade(1f, 1f);
            _gameCanvasGroup.DOFade(0f,0.5f);
        }

        private void FadeOut()
        {
            _canvasGroup.DOFade(0, 1f);
            _gameCanvasGroup.DOFade(1f,0.5f);
        }
    } 
}