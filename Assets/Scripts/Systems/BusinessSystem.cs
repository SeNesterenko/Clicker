using System.Collections.Generic;
using Models;
using ScriptableObject;
using UnityEngine;
using Views;

namespace Systems
{
    public class BusinessSystem : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private BusinessView _businessPrefab;

        private readonly List<BusinessView> _businessViews = new ();
        

        public void Initialize(BusinessModel[] businessModels)
        {
            foreach (var businessModel in businessModels)
            {
                _businessViews.Add(Instantiate(_businessPrefab, _parent));
                _businessViews[^1].Initialize(businessModel);
            }
        }
    }
}