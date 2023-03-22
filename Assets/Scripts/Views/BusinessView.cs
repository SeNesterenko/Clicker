using System;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Views
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _income;
        [SerializeField] private BusinessImprovementView[] _businessImprovementPrefabs;
        [SerializeField] private ProcessIncomeView _processIncomeView;

        [SerializeField] private TMP_Text _levelUpPrice;
        [SerializeField] private Button _levelUpButton;
        
        public void Initialize(BusinessModel model, UnityAction<string> onLevelUp)
        {
            _name.text = model.Name;
            _level.text = "Level " + model.Level;
            _income.text = "Income: " + model.Income;
            _levelUpPrice.text = model.Price + "$";
            
            for (var i = 0; i < _businessImprovementPrefabs.Length; i++)
            {
                _businessImprovementPrefabs[i].Initialize(model.TypesImprovement[i]);
            }
            
            //_levelUpButton.onClick.AddListener(onLevelUp);
            
            _processIncomeView.Initialize();
        }
    }
}