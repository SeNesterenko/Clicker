using Models;
using ScriptableObjects;
using UnityEngine;
using Views;

namespace Systems
{
    public class BusinessSystem : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private BusinessView _businessPrefab;
        [SerializeField] private BusinessConfig _businessConfig;

        private BusinessView[] _businessViews;
        private BusinessModel[] _businessModels;

        private void Start()
        {
            var test = _businessConfig.BusinessModels;
            Initialize(test);
        }

        public void Initialize(BusinessModel[] businessModels)
        {
            _businessModels = businessModels;
            _businessViews = new BusinessView[_businessModels.Length];
            
            for (var i = 0; i < _businessModels.Length; i++)
            {
                _businessViews[i] = Instantiate(_businessPrefab, _parent);
                _businessViews[i].Initialize(_businessModels[i], OnLevelUp);
            }
        }

        public void OnLevelUp()
        {
            
        }
    }
}