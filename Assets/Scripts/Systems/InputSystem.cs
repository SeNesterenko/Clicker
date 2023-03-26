using System;
using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class InputSystem : MonoBehaviour, IDisposable
    {
        private bool _isEscapeLock;
        private CompositeDisposable _subscriptions;

        private void Awake()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<UnlockEscapeEvent>(LockEscape)
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isEscapeLock)
            {
                EventStreams.Game.Publish(new ChangeScreenEvent());
                _isEscapeLock = true;
            }
        }
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }

        private void LockEscape(UnlockEscapeEvent eventData)
        {
            _isEscapeLock = false;
        }
            
    }
}
