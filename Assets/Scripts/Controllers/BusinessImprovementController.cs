using Events;
using Models;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Controllers
{
    public class BusinessImprovementController : MonoBehaviour
    {
        [SerializeField] private BusinessImprovementView _businessImprovementView;
        [SerializeField] private Button _businessImproveButton;
        
        private BusinessImprovementModel _model;
        
        public void Initialize(BusinessImprovementModel model)
        {
            _model = model;
            _businessImproveButton.onClick.AddListener(OnImproveBusiness);
            DisplayView();
        }

        private void OnImproveBusiness()
        {
            EventStreams.Game.Publish(new BusinessImproveWithoutBalanceEvent(_model));
        }

        private void Update()
        {
            DisplayView();
        }

        private void DisplayView()
        {
            var state = _model.IsPurchased ? "Purchased" : _model.Price.ToString();
            _businessImprovementView.DisplayView(_model.Name, _model.BoostIncome.ToString(), state);
        }
    }
}