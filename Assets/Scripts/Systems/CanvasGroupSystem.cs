using System;
using DG.Tweening;
using Events;
using JetBrains.Annotations;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class CanvasGroupSystem : MonoBehaviour, IDisposable
    {
        [SerializeField] private CanvasGroup _gameScreen;
        [SerializeField] private CanvasGroup _menuScreen;
        
        private bool _isPauseScreen;
        private CompositeDisposable _subscriptions;
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }

        private void Awake()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<ChangeScreenEvent>(InitializeChangeState)
            };
        }

        private void InitializeChangeState(ChangeScreenEvent eventData)
        {
            ChangeState();
        }

        private void ChangeState()
        {
            _isPauseScreen = !_isPauseScreen;
            if (_isPauseScreen)
            {
                FadeIn(_gameScreen);
                FadeOut(_menuScreen,0);
            }
            else
            {
                FadeIn(_menuScreen);
                FadeOut(_gameScreen,1);
                EventStreams.Game.Publish(new UnlockEscapeEvent());
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