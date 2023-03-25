using System;
using Newtonsoft.Json;

namespace Models
{
    [Serializable] 
    public class BusinessModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; }
        [JsonProperty(PropertyName = "IncomeDelay")]
        public float IncomeDelay { get; }
        [JsonProperty(PropertyName = "BaseIncome")]
        public float BaseIncome { get; }
        [JsonProperty(PropertyName = "BasePrice")]
        public float BasePrice { get; }
        
        [JsonProperty(PropertyName = "CurrentIncome")]
        public float CurrentIncome { get; set; }
        [JsonProperty(PropertyName = "Level")]
        public int Level { get; set; }
        [JsonProperty(PropertyName = "CurrentPrice")]
        public float CurrentPrice { get; set; }
        
        [JsonProperty(PropertyName = "BusinessImprovementModels")]
        public readonly BusinessImprovementModel[] BusinessImprovementModels;
        
        public BusinessModel(string name, float incomeDelay, int level, float baseIncome, float currentIncome, float currentPrice, BusinessImprovementModel[] businessImprovementModels)
        {
            Name = name;
            IncomeDelay = incomeDelay;
            Level = level;
            BaseIncome = baseIncome;
            CurrentIncome = currentIncome;
            BasePrice = currentPrice;
            CurrentPrice = currentPrice;
            BusinessImprovementModels = businessImprovementModels;
        }
    }
}