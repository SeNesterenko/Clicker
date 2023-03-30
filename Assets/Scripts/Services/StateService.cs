using System;
using DG.Tweening;
using Events;
using FSM;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Services
{
    public class StateService : MonoBehaviour, IDisposable
    {
        [SerializeField] private CanvasGroup _gameScreen;
        [SerializeField] private CanvasGroup _pauseScreen;
        [SerializeField] private GlobalUpdate _globalUpdate;
    
        private StateMachine _stateMachine;
        private CompositeDisposable _subscriptions;

        private bool _isPauseScreen;

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    
        private void Awake()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<ChangeGameStateEvent>(SetGameState)
            };
        
            _stateMachine = new StateMachine();

            _stateMachine.AddState("GameState",
                _ =>
                {
                    FadeOut(_gameScreen);
                },
                state =>
                {
                    if (Input.GetKeyDown(KeyCode.Escape) && state.timer.Elapsed >= 0.5f)
                    {
                        _isPauseScreen = true;
                        _stateMachine.RequestStateChange("PauseState");
                    }
                },
                _ =>
                {
                    FadeIn(_gameScreen);
                });
            
            _stateMachine.AddState("PauseState",
                _ => 
                {
                    FadeOut(_pauseScreen);
                    _globalUpdate.gameObject.SetActive(false);
                },
                _ =>
                {
                    if (!_isPauseScreen)
                    {
                        _stateMachine.RequestStateChange("GameState");
                    }
                },
                _ =>
                {
                    FadeIn(_pauseScreen);
                    _globalUpdate.gameObject.SetActive(true);
                });
        
            _stateMachine.SetStartState("GameState");
        
            _stateMachine.AddTransition("GameState", "PauseState", _ => _isPauseScreen);
            _stateMachine.AddTransition("PauseState", "GameState", _ => !_isPauseScreen);
        
            _stateMachine.Init();
        }

        private void Update()
        {
            _stateMachine.OnLogic();
        }

        private void SetGameState(ChangeGameStateEvent eventData)
        {
            _isPauseScreen = false;
        }
    
        private void FadeIn(CanvasGroup disappearingCanvas)
        {
            disappearingCanvas.DOFade(0f,0.2f).OnComplete(() =>
            {
                disappearingCanvas.gameObject.SetActive(false);
            });
        }

        private void FadeOut(CanvasGroup appearingCanvas)
        {
            appearingCanvas.gameObject.SetActive(true);
            appearingCanvas.DOFade(1f,0.2f);
        }
    }
}