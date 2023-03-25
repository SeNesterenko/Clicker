using System;

namespace Models
{
    [Serializable]
    public class SaveData
    {
        public float Balance { get; private set; }
        public BusinessModel[] BusinessModels { get; private set; }

        public SaveData(float balance, BusinessModel[] businessModels)
        {
            Balance = balance;
            BusinessModels = businessModels;
        }
    }
}