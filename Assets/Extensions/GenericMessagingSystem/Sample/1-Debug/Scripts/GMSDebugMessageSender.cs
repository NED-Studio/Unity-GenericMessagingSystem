using System.Diagnostics;
using UnityEngine;

namespace NED.GenericMessagingSystem.Sample
{
    public class GMSDebugMessageSender : MonoBehaviour
    {
        [SerializeField]
        GMSDebugMessageManager manager;

        public void SendSync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            manager.Broadcast<GlobalMessage, GMSIDebugMessage>((handler) => handler.DebugMessage("Broadcast Synchrously Message"));
            watch.Stop();
            UnityEngine.Debug.Log("Total Time (miliseconds) : " + watch.ElapsedMilliseconds);
        }

        public void SendAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            StartCoroutine(manager.BroadcastAsync<GlobalMessage, GMSIDebugMessage>((handler) => handler.DebugMessage("Broadcast Asynchrously Message")));
            watch.Stop();
            UnityEngine.Debug.Log("Total Time (miliseconds) : " + watch.ElapsedMilliseconds);
        }
    }
}