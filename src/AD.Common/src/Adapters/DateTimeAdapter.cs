using System;

namespace AD.Common
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
        int CurrentUnixTime { get; }
    }

    public class DateTimeAdapter : IDateTime
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }

        public int CurrentUnixTime
        {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return (int)(UtcNow - epoch).TotalSeconds;
            }
        }
    }

}
