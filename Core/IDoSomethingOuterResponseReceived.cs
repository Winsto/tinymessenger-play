
using TinyMessenger;

namespace Core
{
    public interface IDoSomethingOuterResponseReceived : ITinyMessage
    {
        string Message { get; set; }
    }
}
