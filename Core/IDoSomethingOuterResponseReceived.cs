
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingOuterResponseReceived : ITinyMessage, ISessionMessage
    {
        string Message { get; set; }
    }
}
