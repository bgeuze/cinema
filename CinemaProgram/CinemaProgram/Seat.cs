using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Seat
    {
        private char seatRange = 'A';
        private bool seatAvailability = true;
        private double seatPricing = 00.00;

        //Getters and Setters
        public void setSeatRange(char seatRange)
        { this.seatRange = seatRange; }
        public char getSeatRange() { return seatRange; }

        public void setSeatAvailability(bool available)
        { 
        this.seatAvailability = available;
        }
        public bool getSeatAvailability() { return seatAvailability; } 

    }
}
