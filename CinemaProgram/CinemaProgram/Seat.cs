using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    public class Seat
    {
        public char seatRange = 'A';
        public bool seatAvailability = true;
        public double seatPricing = 00.00;
        public string SeatIndex = "0";
        public bool isValid;
        //Constructor
        public Seat(char c,bool valid = true)
        {
            this.seatRange = c;
            switch (c)
            {
                case 'A':
                    seatPricing = 15;
                    break;
                case 'B':
                    seatPricing = 25;
                    break;
                case 'C':
                    seatPricing = 35;
                    break;
            }
            this.isValid = valid;
        }
        
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
