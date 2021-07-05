using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public enum TimeOfDay
    {
        Night,
        Morning,
        Noon,
        Evening
    }

    public class TimeOfDayProvider
    {
        private readonly ISystemClock systemClock;

        public TimeOfDayProvider(ISystemClock systemClock)
        {
            this.systemClock = systemClock;
        }

        public TimeOfDay GetTimeOfDay()
        {
            var now = systemClock.GetNow();
            if (now.Hour >=0 && now.Hour < 6)
            {
                return TimeOfDay.Night;
            }
            if(now.Hour >=6 && now.Hour < 12)
            {
                return TimeOfDay.Morning;
            }
            if (now.Hour >= 12 && now.Hour < 18)
            {
                return TimeOfDay.Noon;
            }
            return TimeOfDay.Evening;
        }
    }
}
