using System;
using Events;
using Models;
using ScriptableObjects;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class ConfigSystem : MonoBehaviour,IDisposable
    {
        [SerializeField] private BusinessConfig _businessConfig;

        private BusinessModel[] _businessModels;
        
        private CompositeDisposable _subscriptions;

        public BusinessModel[] GetBusinesses()
        {
            return _businessModels;
        }

        public BusinessModel[] Initialize()
        {
            CreateBusinessModels();
            return _businessModels;
        }

        private void Awake()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<LevelUpWithoutBalanceEvent>(CountPriceLevelUp),
                EventStreams.Game.Subscribe<TimeIncomeEvent>(CountIncome)
            };
        }

        private void CreateBusinessModels()
        {
            _businessModels = new BusinessModel[_businessConfig.BusinessModels.Length];

            for (var i = 0; i < _businessConfig.BusinessModels.Length; i++)
            {
                var businessName = _businessConfig.BusinessModels[i].Name;
                var incomeDelay = _businessConfig.BusinessModels[i].IncomeDelay;
                var level = _businessConfig.BusinessModels[i].Level;
                var income = _businessConfig.BusinessModels[i].Income;
                var price = _businessConfig.BusinessModels[i].Price;
                
                var businessImproves = CreateBusinessImproves(i);

                _businessModels[i] = new BusinessModel(businessName, incomeDelay, level, income, income, price, businessImproves);
            }
        }

        private BusinessImprovementModel[] CreateBusinessImproves(int index)
        {
            var businessImproves = new BusinessImprovementModel[_businessConfig.BusinessModels[index].TypesImprovement.Length];
            for (var j = 0; j < businessImproves.Length; j++)
            {
                var businessImproveName = _businessConfig.BusinessModels[index].TypesImprovement[j].Name;
                var businessImprovePrice = _businessConfig.BusinessModels[index].TypesImprovement[j].Price;
                var businessImproveBoostIncome = _businessConfig.BusinessModels[index].TypesImprovement[j].BoostIncome;
                var businessImproveIsPurchased = _businessConfig.BusinessModels[index].TypesImprovement[j].IsPurchased;

                businessImproves[j] = new BusinessImprovementModel(businessImproveName, businessImprovePrice,
                    businessImproveBoostIncome, businessImproveIsPurchased);
            }

            return businessImproves;
        }

        private void CountIncome(TimeIncomeEvent eventData)
        {
            var businessModel = eventData.BusinessModel;
            
            var firstImproveBoost = businessModel.BusinessImprovementModels[0].IsPurchased ?
                businessModel.BusinessImprovementModels[0].BoostIncome : 0;
            var secondImproveBoost = businessModel.BusinessImprovementModels[1].IsPurchased ? 
                businessModel.BusinessImprovementModels[1].BoostIncome : 0;
            
            businessModel.Income = businessModel.Level * businessModel.BaseIncome * (1 + firstImproveBoost
                                                            + businessModel.BaseIncome / 100 * secondImproveBoost);
            Debug.Log(businessModel.Income);
            EventStreams.Game.Publish(new BalanceUpEvent(businessModel.Income));
        }

        private void CountPriceLevelUp(LevelUpWithoutBalanceEvent eventData)
        {
            var businessModel = eventData.BusinessModel;
            businessModel.Price = (businessModel.Level + 1) * businessModel.Price;
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}
