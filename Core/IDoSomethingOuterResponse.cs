
using System;
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingOuterResponse : ITinyMessage, ISessionMessage
    {
        int Response { get; set; }
    }
}
