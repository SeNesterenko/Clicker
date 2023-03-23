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
            var playerModel = eventData.PlayerBalanceModel;
            var improvementBusiness = eventData.BusinessImprovementModel;

            if (playerModel.Balance >= improvementBusiness.Price)
            {
                improvementBusiness.IsPurchased = true;
                playerModel.Balance -= improvementBusiness.Price;
            }
        }
        
        private void LevelUp(LevelUpWithBalanceEvent eventData)
        {
            var playerModel = eventData.PlayerBalanceModel;
            var businessModel = eventData.BusinessModel;

            if (playerModel.Balance >= businessModel.Price)
            {
                businessModel.Level += 1;
                playerModel.Balance -= businessModel.Price;
                EventStreams.Game.Publish(new LevelPriceUpEvent(eventData.BusinessModel));
            }
           
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}