
using System;
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingInnerResponse:ITinyMessage

    {
        int Result { get; set; }
        Action<object> cb { get; set; }

    }
}