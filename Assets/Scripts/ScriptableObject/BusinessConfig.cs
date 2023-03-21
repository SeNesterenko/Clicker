
using Models;
using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "BusinessConfig", menuName = "BusinessConfig")]
    public class BusinessConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private BusinessModel[] _businessModel;
    }
}
