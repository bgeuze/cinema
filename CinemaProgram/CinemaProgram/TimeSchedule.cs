using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class TimeSchedule
    {
        private Slot[] daySlots;

        public void addSlot(Slot timeSlot)
        {
            Slot[] temp = new Slot[daySlots.Length + 1];
            for (int i=0; i < daySlots.Length; i++)
            {
                temp[i] = daySlots[i];
            }
            temp[temp.Length - 1] = timeSlot;
            Array.Sort(daySlots);
        }

        public Slot[] getSlots()
        { 
            return daySlots;
        }
    }
}
