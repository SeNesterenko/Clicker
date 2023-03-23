namespace Models
{
    public class BusinessModel
    {
        public string Name { get; }
        public float IncomeDelay { get; }
        
        public int Level { get; set; }
        public float Income { get; set; }
        public float Price { get; set; }
        public BusinessImprovementModel[] BusinessImprovementModels;
        
        public BusinessModel(string name, float incomeDelay, int level, float income, float price, BusinessImprovementModel[] businessImprovementModels)
        {
            Name = name;
            IncomeDelay = incomeDelay;
            Level = level;
            Income = income;
            Price = price;
            BusinessImprovementModels = businessImprovementModels;
        }
    }
}