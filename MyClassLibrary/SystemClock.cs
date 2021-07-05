using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class SystemClock : ISystemClock
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
