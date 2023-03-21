using System;
using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "Business", menuName = "Business")]
    public class Business : UnityEngine.ScriptableObject
    {
        public string NameBusiness => _nameBusiness;
        public int CurrentLelev => _currentLevel;
        public int Progress => _progress;
        public int IncomeProgress => _incomeProgress;   

        [SerializeField]
        private string _nameBusiness;
        [SerializeField]
        private int _currentLevel;
        [SerializeField]
        private int _progress;
        [SerializeField] 
        private int _incomeProgress;


    }
}
