using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class WeekSchedule
    {
        private TimeSchedule[] timeSchedule;

        public void addSchedule(TimeSchedule schedule)
        {
            TimeSchedule[] temp = new TimeSchedule[timeSchedule.Length + 1];
            for (int i = 0; i < timeSchedule.Length; i++)
            {
                temp[i] = timeSchedule[i];
            }
            temp[temp.Length - 1] = schedule;
            //Array.Sort(daySlots);
        }

        public TimeSchedule[] getSchedule() { return timeSchedule; }
    }
}
