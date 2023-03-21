using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "BusinessImprovement", menuName = "ImprovementsBusiness")]
    public class TypesBusinessImprovement : UnityEngine.ScriptableObject
    {
        public string ImprovementsName => _improvementsName;
        public bool Buy => _buy;
        public int UpgradePrice => _upgradePrice;
        public int Income => _income;
        
        
        [SerializeField] 
        private string _improvementsName;
        [SerializeField] 
        private bool _buy;
        [SerializeField]
        private int _upgradePrice;
        [SerializeField]
        private int _income;
    }
}
