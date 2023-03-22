using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _income;
        [SerializeField] private BusinessImprovementView[] _businessImprovementPrefabs;
        [SerializeField] private ProcessIncomeView _processIncome;

        private Timer _timer;

        public void Initialize(BusinessModel model)
        {
            _name.text = model.Name;
            _level.text = "Level " + model.Level;
            _income.text = "Income: " + model.Income;
            
            for (var i = 0; i < _businessImprovementPrefabs.Length; i++)
            {
                _businessImprovementPrefabs[i].Initialize(model.TypesImprovement[i]);
            }
        }
    }
}