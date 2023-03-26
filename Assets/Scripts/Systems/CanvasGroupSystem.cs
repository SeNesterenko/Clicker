using DG.Tweening;
using UnityEngine;

namespace Systems
{
    public class CanvasGroupSystem : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _gameScreen;
        [SerializeField] private CanvasGroup _gameOverScreen;
        
        private bool _isPauseScreen;

        public void MenuGame()
        {
            if (!_isPauseScreen)
            {
                FadeIn(_gameScreen);
                FadeOut(_gameOverScreen,0);
                _isPauseScreen = true;
            }
            else
            {
                FadeIn(_gameOverScreen);
                FadeOut(_gameScreen,1);
                _isPauseScreen = false;
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