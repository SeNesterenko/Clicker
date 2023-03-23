using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BusinessImprovementView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _boostIncome;
        [SerializeField] private TMP_Text _state;

        [SerializeField] private string _purchasedText = "Purchased";

        public void Initialize(BusinessImprovementModel model)
        {
            _boostIncome.text = "Income: " + model.BoostIncome + "$";
            _name.text = model.Name;
            _state.text = "Price: " + model.Price + "$";
        }
    }
}