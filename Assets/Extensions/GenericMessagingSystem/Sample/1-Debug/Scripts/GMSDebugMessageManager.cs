namespace NED.GenericMessaingSystem.Sample
{
    public class GMSDebugMessageManager : BaseMessagingManager
    {
        protected override void CreateAllStorage()
        {
            CreateStorage<GlobalMessage, GMSIDebugMessage>();
        }

        protected override void DestoryAllStorage()
        {
            DestroyStorage<GlobalMessage, GMSIDebugMessage>();
        }
    }
}