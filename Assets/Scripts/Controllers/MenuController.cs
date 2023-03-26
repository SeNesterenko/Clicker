using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _startOver;
        [SerializeField] private Button _exitGameWithoutSave;
        [SerializeField] private Button _exitGame;

        private void Awake()
        {
            _exitGameWithoutSave.onClick.AddListener(OnExitGame);
        }

        private void OnExitGame()
        {
            EventStreams.Game.Publish(new ExitGameEvent());
        }
    }
}
