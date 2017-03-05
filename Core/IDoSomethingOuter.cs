
using System;
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingOuter : ITinyMessage
    {
        int x { get; set; }
        int y { get; set; }
        Action<object> cb { get; set; }

    }


}