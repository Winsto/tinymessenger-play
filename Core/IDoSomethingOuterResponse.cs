
using System;
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingOuterResponse : ITinyMessage
    {
        int Response { get; set; }
        Action<object> cb { get; set; }

    }
}
