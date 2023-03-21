using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class BusinessModel
    {
        public string Name => _name;
        public int Level => _level;
        public float Income => _income;
        public BusinessImprovementModel[] TypesImprovement => _typesImprovement;
        
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private float _income;
        [SerializeField] private BusinessImprovementModel[] _typesImprovement;
    }
}