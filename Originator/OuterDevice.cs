using Core;
using System;
using System.Collections.Generic;
using TinyMessenger;

namespace Originator
{
    public class OuterDevice
    {
        private TinyMessengerHub _msgr;
        private Dictionary<Guid, Action<object>> _callbacks;
        public OuterDevice(TinyMessengerHub msgr)
        {
            _msgr = msgr;
            _callbacks = new Dictionary<Guid, Action<object>>();
            subscribe();
           
        }

        private void subscribe()
        {
            _msgr.Subscribe<IDoSomethingOuterResponse>(msg =>
            {
                Console.WriteLine("Outer:DoSomethingOuterResponse");
                Action<object> callback =_callbacks[msg.SessionUid];
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
            var sessionUid = Guid.NewGuid();
            _callbacks.Add(sessionUid, callback);

            IDoSomethingOuter outerMsg = new DoSomethingOuter(this) { x = x, y = y, SessionUid=sessionUid };
            _msgr.Publish<IDoSomethingOuter>(outerMsg);

        }
        
    }
}
