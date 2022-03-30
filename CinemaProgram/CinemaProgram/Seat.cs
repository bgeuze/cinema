using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Seat
    {
        public char seatRange = 'A';
        public bool seatAvailability = true;
        public double seatPricing = 00.00;

        //Getters and Setters
        public void setSeatRange(char seatRange)
        { this.seatRange = seatRange; }
        public char getSeatRange() { return seatRange; }

        public void setSeatAvailability(bool available)
        { 
        this.seatAvailability = available;
        }
        public bool getSeatAvailability() { return seatAvailability; }
        public void setPricing(double newPrice) { seatPricing = newPrice; }
        public double getPrice() { return seatPricing; }
    }
}
