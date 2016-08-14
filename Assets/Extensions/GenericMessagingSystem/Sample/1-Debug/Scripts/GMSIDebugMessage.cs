namespace NED.GenericMessagingSystem.Sample
{
    public interface GMSIDebugMessage : IMessageListener
    {
        void DebugMessage(string message);
    }
}