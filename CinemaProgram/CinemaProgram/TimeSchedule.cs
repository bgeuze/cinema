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
            Slot[] temp = daySlots.Length +1;
            for (int i; i < daySlots; i++)
            {
                temp[i] = daySlots[i];
            }
            temp[temp.Length - 1] = TimeSlot;
            daySlots = temp;
            SortList();
        }

        public void addSlotBetween()
        {

        }

        public void SortList()
        {
            Slot[] nonSorted = daySlots;
            Slot[] sortedMovies = daySlots.Length;
            for (int i; i < sortedMovies.Length; i++)
            {
                
            }
            return sortedMovies;
        }

    }
}
