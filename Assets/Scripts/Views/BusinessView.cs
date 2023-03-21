using TMPro;
using UnityEngine;

namespace Views
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _income;
        [SerializeField] private BusinessUpgradeView[] _businessUpgrade;
        [SerializeField] private ProcessIncomeView _processIncome;

        private Timer _timer;
    }
}