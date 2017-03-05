using System;
using Core;
using TinyMessenger;

namespace Originator
{
    public class DoSomethingOuter : TinyMessageBase,IDoSomethingOuter
    {
        

        public DoSomethingOuter(object sender) : base(sender)
        {
        }

        public Guid SessionUid { get; set; }

        public int x { get; set; }
        public int y { get; set; }
    }
    public class DoSomethingOuterResponse : TinyMessageBase, IDoSomethingOuterResponse
    {
        public DoSomethingOuterResponse(object sender) : base(sender)
        {
        }
        public Guid SessionUid { get; set; }
        public int Response { get; set; }
    }
    public class DoSomethingOuterResponseReceived : TinyMessageBase, IDoSomethingOuterResponseReceived
    {
        public DoSomethingOuterResponseReceived(object sender) : base(sender)
        {
        }
        public Guid SessionUid { get; set; }
        public string Message { get; set; }
    }
}