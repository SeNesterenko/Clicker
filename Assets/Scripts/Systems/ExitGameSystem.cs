using System;
using Controllers;
using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class ExitGameSystem : MonoBehaviour,IDisposable
    {
        private CompositeDisposable _subscriptions;

        private void Awake()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<ExitGameEvent>(ExitGame)
            };
        }
        
        private void ExitGame(ExitGameEvent eventData)
        {
            
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}
