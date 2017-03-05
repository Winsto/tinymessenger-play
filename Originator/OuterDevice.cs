using Core;
using System;
using TinyMessenger;

namespace Originator
{
    public class OuterDevice
    {
        private TinyMessengerHub _msgr;

        public OuterDevice(TinyMessengerHub msgr)
        {
            _msgr = msgr;
            subscribe();
           
        }

        private void subscribe()
        {
            _msgr.Subscribe<IDoSomethingOuterResponse>(msg =>
            {
                Console.WriteLine("Outer:DoSomethingOuterResponse");
                Action<object> callback = msg.cb;
                callback(msg);
            }); 
        }
        
        public void TriggerPublish()
        {
            Console.WriteLine("Outer:TriggerPublish");
            var x = 1;
            var y = 2;
            Action<object> callback = outerResponse =>
            {
                Console.WriteLine("Outer:OuterResponse Callback");
                var resp = (IDoSomethingOuterResponse)outerResponse;
                IDoSomethingOuterResponseReceived msg = new DoSomethingOuterResponseReceived(this)
                {
                    Message = String.Format("{0}*{1}={2}", x, y, resp.Response)
                };
                _msgr.Publish<IDoSomethingOuterResponseReceived>(msg);
            };

            IDoSomethingOuter outerMsg = new DoSomethingOuter(this) { x = x, y = y, cb=callback };
            _msgr.Publish<IDoSomethingOuter>(outerMsg);

        }
        
    }
}
