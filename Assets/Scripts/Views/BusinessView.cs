using TMPro;
using UnityEngine;

namespace Views
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _income;
        [SerializeField] private BusinessUpgradeView[] _businessUpgrade;

        private Timer _timer;
    }
}