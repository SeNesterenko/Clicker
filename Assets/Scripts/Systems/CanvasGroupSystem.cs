using DG.Tweening;
using UnityEngine;

namespace Systems
{
    public class CanvasGroupSystem : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _gameCanvasGroup;
        [SerializeField] private CanvasGroup _gameOverCanvasGroup;

        private Tween _tween;
        private bool _canvasVisible;
        private bool _fadeIn;
        private bool _fadeOut;
        
        public void MenuGame()
        {
            if (!_canvasVisible)
            {
                FadeIn(_gameCanvasGroup);
                FadeOut(_gameOverCanvasGroup,0);
                _canvasVisible = true;
            }
            else
            {
                FadeIn(_gameOverCanvasGroup);
                FadeOut(_gameCanvasGroup,1);
                _canvasVisible = false;
            }
            
        }

        private void FadeIn(CanvasGroup disappearingCanvas)
        {
            Time.timeScale = 1;
            disappearingCanvas.DOFade(0f,0.5f).OnComplete(() =>
            {
                disappearingCanvas.gameObject.SetActive(false);
            });
        }

        private void FadeOut(CanvasGroup appearingCanvas,int currentTimeScale)
        {
            appearingCanvas.gameObject.SetActive(true);
            appearingCanvas.DOFade(1f,0.5f).OnComplete(() => Time.timeScale = currentTimeScale);
        }
        
    } 
}