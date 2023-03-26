using UnityEngine;
using UnityEngine.Events;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _escapeExit;
        
        public void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                _escapeExit.Invoke();
            }
        }
    }
}
