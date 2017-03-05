using System;
using TinyMessenger;

namespace Actor
{
    public interface IDoSomethingInner:ITinyMessage
    {
        int a { get; set; }
        int b { get; set; }
        Action<object> cb { get; set; }

    }
}