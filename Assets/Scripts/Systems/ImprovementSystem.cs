using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class ImprovementSystem : MonoBehaviour
    {
        private CompositeDisposable _subscriptions;
        
        public void Initialize()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<LevelUpWithBalanceEvent>(LevelUp)
            };
        }

        private void LevelUp(LevelUpWithBalanceEvent eventData)
        {
            Debug.Log(eventData.BusinessModel.Name);
            Debug.Log(eventData.PlayerBalanceModel.Balance);
        }
    }
}