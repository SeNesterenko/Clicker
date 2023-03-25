using Controllers;
using Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace Systems
{
    public class BusinessSystem : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private BusinessController _businessControllerPrefab;

        public void Initialize(BusinessModel[] businessModels)
        {
            foreach (var model in businessModels)
            {
                var businessController = Instantiate(_businessControllerPrefab, _parent);
                businessController.Initialize(model);
            }
        }
    }
}