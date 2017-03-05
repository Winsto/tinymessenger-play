using Core;
using System;
using TinyMessenger;

namespace Actor
{
    public interface IDoSomethingInner:ISessionMessage,ITinyMessage
    {
        int a { get; set; }
        int b { get; set; }
    }
}