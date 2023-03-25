using System;
using Newtonsoft.Json;

namespace Models
{
    [Serializable] 
    public class BusinessModel
    {
        public string Name { get; }
        public float IncomeDelay { get; }
        public float BaseIncome { get; }
        public float BasePrice { get; }
        
        public float CurrentIncome { get; set; }
        public int Level { get; set; }
        public float CurrentPrice { get; set; }
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