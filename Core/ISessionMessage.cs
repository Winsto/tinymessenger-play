using System;


namespace Core
{
    public interface ISessionMessage
    {
        Guid SessionUid { get; set; }
    }
}
