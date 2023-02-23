using ChainOfResponsibility_Phones_.Handlers;

namespace ChainOfResponsibility_Phones_
{
    internal class Mobile
    {
        public static void Main(string[] args)
        {
            IPhoneHandler batteryHandler = new BatteryHandler();
            IPhoneHandler storageHandler = new StorageHandler();
            IPhoneHandler cameraHandler = new CameraHandler();
            IPhoneHandler unsupported = new UnsupportedRequestHandler();

            batteryHandler.SetNext(storageHandler).SetNext(cameraHandler).SetNext(unsupported);

            batteryHandler.HandleRequest("battery");
            batteryHandler.HandleRequest("storage");
            batteryHandler.HandleRequest("camera");
            batteryHandler.HandleRequest("unsupported");
        }
    }
}