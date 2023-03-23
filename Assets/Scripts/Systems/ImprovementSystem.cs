using System;
using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class ImprovementSystem : MonoBehaviour, IDisposable
    {
        private CompositeDisposable _subscriptions;
        
        public void Initialize()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<LevelUpWithBalanceEvent>(LevelUp),
                EventStreams.Game.Subscribe<BusinessImproveWithBalanceEvent>(ImproveBusiness)
            };
        }

        private void ImproveBusiness(BusinessImproveWithBalanceEvent eventData)
        {
            Debug.Log(eventData.BusinessImprovementModel.Name);
            Debug.Log(eventData.PlayerBalanceModel.Balance);
        }
        
        private void LevelUp(LevelUpWithBalanceEvent eventData)
        {
            Debug.Log(eventData.BusinessModel.Name);
            Debug.Log(eventData.PlayerBalanceModel.Balance);
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}