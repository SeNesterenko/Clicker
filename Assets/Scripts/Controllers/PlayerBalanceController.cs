using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class PlayerBalanceController : MonoBehaviour
    {
        [SerializeField] private PlayerBalanceView _playerBalanceView;

        private PlayerBalanceModel _model;

        public void Initialize(float startBalance)
        {
            _model = new PlayerBalanceModel
            {
                Balance = startBalance
            };
            DisplayView();
        }

        public PlayerBalanceModel GetPlayerModel()
        {
            return _model;
        }

        private void DisplayView()
        {
            _playerBalanceView.DisplayView(_model.Balance.ToString());
        }

        private void Update()
        {
            DisplayView();
        }
    }
}