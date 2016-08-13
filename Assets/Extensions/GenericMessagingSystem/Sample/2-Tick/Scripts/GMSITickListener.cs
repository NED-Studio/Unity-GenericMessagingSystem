namespace NED.GenericMessaingSystem.Sample
{
    public interface GMSITickListener : IMessageListener
    {
        void OnTotalTickUpdated(GMSTickManager tickManager);
        void OnTickStatusUpdated(GMSTickManager tickManager);
    }
}
