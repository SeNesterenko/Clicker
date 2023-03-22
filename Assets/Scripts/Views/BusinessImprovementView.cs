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
            _name.text = model.Name;
            _boostIncome.text = "Income: " + model.BoostIncome + "$";
            _state.text = "Price: " + model.Price + "$";
        }
    }
}