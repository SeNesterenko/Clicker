using Controllers;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    public class BusinessSystem : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private BusinessController _businessPrefab;
        [SerializeField] private BusinessConfig _businessConfig;

        private void Start()
        {
            var test = _businessConfig.BusinessModels;
            Initialize(test);
        }

        public void Initialize(BusinessModel[] businessModels)
        {
            foreach (var model in businessModels)
            {
                var businessController = Instantiate(_businessPrefab, _parent);
                businessController.Initialize(model);
            }
        }
    }
}