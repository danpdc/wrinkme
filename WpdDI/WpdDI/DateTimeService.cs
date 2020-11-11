using System;
using System.Collections.Generic;
using System.Text;

namespace WpdDI
{
    public class DateTimeService : IDateTimeService
    {
        public string GetDateTimeString()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
