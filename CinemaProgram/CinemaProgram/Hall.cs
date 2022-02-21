using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Hall
    {
        private Seat[][] seats;
        private Seat testSeat;
        private int hallNumber;
        private Movie movie;
        private string time;

        public Hall(int number, Seat seat)
        { 
            this.hallNumber = number;
            this.testSeat = seat;
        }

        public void setHallNumber(int number)
        { 
            hallNumber = number; 
        }
        public int getHallNumber() { return hallNumber; }
    }
}
