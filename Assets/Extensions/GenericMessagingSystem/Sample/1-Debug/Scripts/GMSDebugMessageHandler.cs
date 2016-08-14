using UnityEngine;

namespace NED.GenericMessagingSystem.Sample
{
    public class GMSDebugMessageHandler : MonoBehaviour, GMSIDebugMessage
    {
        [SerializeField]
        GMSDebugMessageManager manager;

        void OnEnable()
        {
            manager.Add<GlobalMessage, GMSIDebugMessage>(this);
        }

        void OnDisable()
        {
            manager.Remove<GlobalMessage, GMSIDebugMessage>(this);
        }

        public void DebugMessage(string message)
        {
            Debug.Log(message);
        }
    }
}
