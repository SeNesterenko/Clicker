using System;

namespace Models
{
    [Serializable]
    public class SaveData
    {
        public float Balance { get; }
        public BusinessModel[] BusinessModels { get; }

        public SaveData(float balance, BusinessModel[] businessModels)
        {
            Balance = balance;
            BusinessModels = businessModels;
        }
    }
}