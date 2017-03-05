
using System;
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingOuter : ITinyMessage, ISessionMessage
    {
        int x { get; set; }
        int y { get; set; }
    }


}