using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _continue;
        [SerializeField] private Button _startOver;
        [SerializeField] private Button _exitGameWithoutSave;
        [SerializeField] private Button _exitGame;

        private void Awake()
        {
            
        }
    }
}