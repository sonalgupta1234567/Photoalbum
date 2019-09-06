namespace Marvel.Services.Utility
{
    public class TimeStamp  : ITimeStamp
    {
        private readonly ISystemClock _systemClock;

        public TimeStamp()
        {
            _systemClock = new SystemClock();
        }

        public TimeStamp(ISystemClock systemClock)
        {
            _systemClock = systemClock;
        }

        public string GetTimestamp()
        {
            return _systemClock.Now.ToString(Constants.DateTimeFormat);
        }
    }
}
