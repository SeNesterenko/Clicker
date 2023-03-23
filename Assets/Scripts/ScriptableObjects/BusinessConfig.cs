using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BusinessConfig", menuName = "BusinessConfig")]
    public class BusinessConfig : ScriptableObject
    {
        public ConfigBusinessModel[] BusinessModels => _businessModel;
        public float StartPlayerBalance => _startPlayerBalance;
        
        [SerializeField] private ConfigBusinessModel[] _businessModel;
        [SerializeField] private float _startPlayerBalance;
    }
}
