using System;

namespace Marvel.Services
{
    public interface ISystemClock
    {
        DateTime Now { get; }
    }
}