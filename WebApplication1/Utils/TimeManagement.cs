using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public static class TimeManagement
    {
        public static int GetDay()
        {
            DateTime myDateTime = DateTime.Now;
            int time = 0;
            switch (myDateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    time = 0;
                    break;
                case DayOfWeek.Tuesday:
                    time = 1;
                    break;
                case DayOfWeek.Wednesday:
                    time = 2;
                    break;
                case DayOfWeek.Thursday:
                    time = 3;
                    break;
                case DayOfWeek.Friday:
                    time = 4;
                    break;
                case DayOfWeek.Saturday:
                    time = 5;
                    break;
                case DayOfWeek.Sunday:
                    time = 6;
                    break;
            }
            return time;
        }
    }
}
