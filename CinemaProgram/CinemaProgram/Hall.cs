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
        private int hallNumber;
        private Movie movie;
        private string time;


        public void setHallNumber(int number)
        { 
            hallNumber = number; 
        }
        public int getHallNumber() { return hallNumber; }
    }
}
