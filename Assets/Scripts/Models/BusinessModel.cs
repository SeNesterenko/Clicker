namespace Models
{
    public class BusinessModel
    {
        public string Name { get; }
        public float IncomeDelay { get; }
        public float BaseIncome { get; }
        
        public float Income { get; set; }
        public int Level { get; set; }
        public float Price { get; set; }
        public readonly BusinessImprovementModel[] BusinessImprovementModels;
        
        public BusinessModel(string name, float incomeDelay, int level, float baseIncome, float income, float price, BusinessImprovementModel[] businessImprovementModels)
        {
            Name = name;
            IncomeDelay = incomeDelay;
            Level = level;
            BaseIncome = baseIncome;
            Income = income;
            Price = price;
            BusinessImprovementModels = businessImprovementModels;
        }
    }
}