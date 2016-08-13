namespace NED.GenericMessaingSystem.Sample
{
    public interface GMSIDebugMessage : IMessageListener
    {
        void DebugMessage(string message);
    }
}