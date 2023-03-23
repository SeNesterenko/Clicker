using Controllers;
using Models;
using UnityEngine;

namespace Systems
{
    public class BusinessSystem : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private BusinessController _businessPrefab;
        [SerializeField] private ConfigSystem _configSystem;

        private void Start()
        {
            var test = _configSystem.GetBusinesses();
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