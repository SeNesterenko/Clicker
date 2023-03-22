using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BusinessConfig", menuName = "BusinessConfig")]
    public class BusinessConfig : ScriptableObject
    {
        public BusinessModel[] BusinessModels => _businessModel;
        
        [SerializeField] private BusinessModel[] _businessModel;
    }
}
