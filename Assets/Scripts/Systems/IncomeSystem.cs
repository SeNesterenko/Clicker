using System;
using Controllers;
using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class IncomeSystem : MonoBehaviour, IDisposable
    {
        [SerializeField] private PlayerBalanceController _playerBalanceController;
        
        private CompositeDisposable _subscriptions;

        public void Initialize(float startBalance)
        {
            _playerBalanceController.Initialize(startBalance);
            
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<LevelUpWithoutBalanceEvent>(AddBalanceToEventContext),
                EventStreams.Game.Subscribe<BusinessImproveWithoutBalanceEvent>(AddBalanceToEventContext)
            };
        }

        private void AddBalanceToEventContext(BusinessImproveWithoutBalanceEvent eventData)
        {
            EventStreams.Game.Publish(new BusinessImproveWithBalanceEvent(eventData.BusinessImprovementModel, _playerBalanceController.GetPlayerModel()));
        }
        
        private void AddBalanceToEventContext(LevelUpWithoutBalanceEvent eventData)
        {
            EventStreams.Game.Publish(new LevelUpWithBalanceEvent(eventData.BusinessModel, _playerBalanceController.GetPlayerModel()));
        }
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}
