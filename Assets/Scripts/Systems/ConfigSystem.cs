using Models;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    //Система Конфига: определение формул для расчета и цены повышения уровня бизнеса на основе конфига. Загрузка файлов конфига,
    //их хранение и предоставление доступа для других систем.
    public class ConfigSystem : MonoBehaviour
    {
        [SerializeField] private BusinessConfig _businessConfig;

        private BusinessModel[] _businessModels;

        public BusinessModel[] GetBusinesses()
        {
            return _businessModels;
        }
        
        private void Awake()
        {
            CreateBusinessModels();
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

                var businessImproves = new BusinessImprovementModel[_businessConfig.BusinessModels[i].TypesImprovement.Length];
                for (var j = 0; j < businessImproves.Length; j++)
                {
                    var businessImproveName = _businessConfig.BusinessModels[i].TypesImprovement[j].Name;
                    var businessImprovePrice = _businessConfig.BusinessModels[i].TypesImprovement[j].Price;
                    var businessImproveBoostIncome = _businessConfig.BusinessModels[i].TypesImprovement[j].BoostIncome;
                    var businessImproveIsPurchased = _businessConfig.BusinessModels[i].TypesImprovement[j].IsPurchased;

                    businessImproves[j] = new BusinessImprovementModel(businessImproveName, businessImprovePrice,
                        businessImproveBoostIncome, businessImproveIsPurchased);
                }

                _businessModels[i] = new BusinessModel(businessName, incomeDelay, level, income, price, businessImproves);
            }
        }
    }
}
