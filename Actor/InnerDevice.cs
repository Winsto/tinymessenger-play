using Core;
using System;
using TinyMessenger;

namespace Actor
{
    
    public class InnerDevice
    {
        private ITinyMessengerHub _msgr;

        public InnerDevice(ITinyMessengerHub msgr)
        {
            _msgr = msgr;
            subscribe();
           
        }

        private void subscribe()
        {
            _msgr.Subscribe<IDoSomethingInner>(onDoSomethingMessage);
        }

        private void onDoSomethingMessage(IDoSomethingInner obj)
        {
            Console.WriteLine("Inner:onDoSomethingInner");
            IDoSomethingInnerResponse resp = new DoSomethingInnerResponse(this) { Result=obj.a*obj.b,
            cb=obj.cb};
            _msgr.Publish<IDoSomethingInnerResponse>(resp);
        }
    }
}
