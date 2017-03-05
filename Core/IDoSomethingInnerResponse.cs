
using System;
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingInnerResponse:ITinyMessage, ISessionMessage

    {
        int Result { get; set; }
    }
}