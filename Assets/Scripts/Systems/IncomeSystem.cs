using System;
using Events;
using Models;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class IncomeSystem : MonoBehaviour, IDisposable
    {
        private PlayerBalanceModel _playerBalanceModel;
        private CompositeDisposable _subscriptions;

        public void Initialize(float startBalance)
        {
            _playerBalanceModel = new PlayerBalanceModel
            {
                Balance = startBalance
            };
            
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<LevelUpWithoutBalanceEvent>(AddBalanceToEventContext)
            };
        }
        
        private void AddBalanceToEventContext(LevelUpWithoutBalanceEvent eventData)
        {
            EventStreams.Game.Publish(new LevelUpWithBalanceEvent(eventData.BusinessModel, _playerBalanceModel));
        }
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}
