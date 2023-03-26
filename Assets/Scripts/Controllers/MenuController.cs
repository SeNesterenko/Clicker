using Events;
using SimpleEventBus.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _continue;
        [SerializeField] private Button _newGame;
        [SerializeField] private Button _exitGameWithoutSave;
        [SerializeField] private Button _exitGame;

        private void Awake()
        {
            _newGame.onClick.AddListener(OnStartNewGame);
            
            _exitGameWithoutSave.onClick.AddListener(OnExitGame);
            
            _exitGame.onClick.AddListener(OnSaveGame);
            _exitGame.onClick.AddListener(OnExitGame);
            
            _continue.onClick.AddListener(OnContiueGame);
        }
        public void OnContiueGame()
        {
            EventStreams.Game.Publish(new ContinueGameEvent());
        }

        private void OnSaveGame()
        {
            EventStreams.Game.Publish(new SaveGameEvent());
        }

        private void OnExitGame()
        {
            EventStreams.Game.Publish(new ExitGameEvent());
        }

        private void OnStartNewGame()
        {
            EventStreams.Game.Publish(new NewGameEvent());
            EventStreams.Game.Publish(new ChangeScreenEvent());
        }
    }
}
