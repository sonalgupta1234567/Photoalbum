using System;

namespace Marvel.Services
{
    public class SystemClock : ISystemClock
    {
        public DateTime Now => DateTime.Now;
    }
}