using Actor;
using Core;
using Originator;
using System;

using TinyMessenger;

namespace MessageLayer
{
    public class Handler
    {
        private TinyMessengerHub _msgr;

        public Handler(TinyMessengerHub msgr)
        {
            _msgr = msgr;
            subscribe();
        }

        private void subscribe()
        {
            _msgr.Subscribe<IDoSomethingOuter>(onDoSomethingOuter); //request comes in from outer
            //_msgr.Subscribe<IDoSomethingInner>(onDoSomethingInner); //processes
            _msgr.Subscribe<IDoSomethingInnerResponse>(onDoSomethingInnerResponse);//returns

            //_msgr.Subscribe<IDoSomethingOuterResponse>(onDoSomethingOuterResponse);//passed to outer
            _msgr.Subscribe<IDoSomethingOuterResponseReceived>(onDoSomethingOuterResponseReceived);//verify response

        }

        private void onDoSomethingOuterResponseReceived(IDoSomethingOuterResponseReceived obj)
        {
            Console.WriteLine("Success! {0}",obj.Message);
        }

        private void onDoSomethingOuterResponse(IDoSomethingOuterResponse obj)
        {
            //throw new NotImplementedException();
        }

        private void onDoSomethingInnerResponse(IDoSomethingInnerResponse obj)
        {
            Console.WriteLine("Handler:onDoSomethingInnerResponse");

            IDoSomethingOuterResponse msg = new DoSomethingOuterResponse(this)
            {
                Response = obj.Result,
                SessionUid = obj.SessionUid
            };
            _msgr.Publish<IDoSomethingOuterResponse>(msg);
        }

        private void onDoSomethingInner(IDoSomethingInner obj)
        {
           // throw new NotImplementedException();
        }

        private void onDoSomethingOuter(IDoSomethingOuter obj)
        {
            Console.WriteLine("Handler:onDoSomethingOuter");
            var msg = new DoSomethingInner(this)
            {
                a = obj.x,
                b = obj.y,
                SessionUid = obj.SessionUid
            };
            _msgr.Publish<IDoSomethingInner>(msg);
        }
    }
}
