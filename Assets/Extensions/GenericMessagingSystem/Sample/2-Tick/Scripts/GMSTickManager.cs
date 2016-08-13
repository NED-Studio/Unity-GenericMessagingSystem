using UnityEngine;

namespace NED.GenericMessaingSystem.Sample
{
    public sealed class GMSTickManager : BaseMessagingManager
    {
        private bool m_IsRunning = false;
        private float m_Total = 0;
        [SerializeField]
        private float m_TickTime = 1f;

        private float tempTick = 0;

        public float Total
        {
            get { return m_Total; }
            private set
            {
                m_Total = value;

                Broadcast<GlobalMessage, GMSITickListener>((handler) => handler.OnTotalTickUpdated(this));
            }
        }

        public bool IsRunning
        {
            get { return m_IsRunning; }
            private set
            {
                m_IsRunning = value;

                Broadcast<GlobalMessage, GMSITickListener>((handler) => handler.OnTickStatusUpdated(this));
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (IsRunning)
            {
                tempTick += Time.deltaTime;

                if (tempTick >= m_TickTime)
                {
                    Total += 1;
                    tempTick = 0;
                }
            }
        }

        protected override void CreateAllStorage()
        {
            CreateStorage<GlobalMessage, GMSITickListener>();
        }

        protected override void DestoryAllStorage()
        {
            DestroyStorage<GlobalMessage, GMSITickListener>();
        }

        public void StartTick()
        {
            IsRunning = true;
        }

        public void StopTick()
        {
            IsRunning = false;
        }

        public void ResetTick()
        {
            Total = 0;
            tempTick = 0;
        }
    }
}
