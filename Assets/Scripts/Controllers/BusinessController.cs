using Events;
using Models;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Controllers
{
    public class BusinessController : MonoBehaviour
    {
        [SerializeField] private BusinessView _businessView;
        [SerializeField] private ProcessIncomeView _processIncomeView;
        [SerializeField] private BusinessImprovementController[] _businessImprovementControllers;
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private Timer _timer;

        private BusinessModel _model;

        public void Initialize(BusinessModel model)
        {
            _model = model;
            _timer.Initialize(model.IncomeDelay, _processIncomeView);
            
            for (var i = 0; i < _businessImprovementControllers.Length; i++)
            {
                _businessImprovementControllers[i].Initialize(_model.BusinessImprovementModels[i]);
            }
            
            _levelUpButton.onClick.AddListener(OnLevelUp);
            DisplayView();
        }

        private void OnLevelUp()
        {
            EventStreams.Game.Publish(new LevelUpWithoutBalanceEvent(_model));
        }

        private void DisplayView()
        {
            _businessView.DisplayView(_model.Name, _model.Level.ToString(), _model.Income.ToString(), _model.Price.ToString());
        }

        private void Update()
        {
            DisplayView();
        }
    }
}