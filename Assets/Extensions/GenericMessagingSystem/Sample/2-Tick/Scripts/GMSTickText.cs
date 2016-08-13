using UnityEngine;
using UnityEngine.UI;

namespace NED.GenericMessaingSystem.Sample
{
    [RequireComponent(typeof(Text))]
    public class GMSTickText : MonoBehaviour, GMSITickListener
    {
        [SerializeField] GMSTickManager manager;

        private Text UIText;

        protected void OnEnable()
        {
            manager.Add<GlobalMessage, GMSITickListener>(this);
        }

        protected void OnDisable()
        {
            manager.Remove<GlobalMessage, GMSITickListener>(this);
        }

        void Start()
        {
            UIText = GetComponent<Text>();
        }

        public void OnTickStatusUpdated(GMSTickManager tickManager)
        {
            if (!tickManager.IsRunning)
            {
                UIText.text = ((int)tickManager.Total) + " (Paused)";
            }

        }

        public void OnTotalTickUpdated(GMSTickManager tickManager)
        {
            UIText.text = ((int)tickManager.Total).ToString();
        }
    }
}
