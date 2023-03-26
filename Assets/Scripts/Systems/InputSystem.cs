using Events;
using UnityEngine;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EventStreams.Game.Publish(new ChangeScreenEvent());
            }
        }
    }
}
