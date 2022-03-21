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
<<<<<<< Updated upstream
=======
       // private Seat testSeat;
>>>>>>> Stashed changes
        private int hallNumber;
        //private Movie movie;
        //private string time;

<<<<<<< Updated upstream

=======
        public Hall(int number, Seat[][] seat)
        { 
            this.hallNumber = number;
            seats = new Seat[seat.Length(0)][];
            for (int i; i < seat.GetLength(0); i++)
            {
                for (int j = 0; seat.GetLength(1); j++)
                    seats[i][j] = seat[i][j];
            }
        }
        public void setRange(int row, int column, char Range)
        {
            seats[row][column].setSeatRange(Range);
        }
>>>>>>> Stashed changes
        public void setHallNumber(int number)
        { 
            hallNumber = number; 
        }
        public int getHallNumber() { return hallNumber; }

        public Seat[][] getSeats() { return seats; }

        public Seat getSpecificSeat(int row, int column)
        { return seats[row][column]; }

        public bool setAvailability(int row, int column)
        {
            if (!seats[row][column].getSeatAvailability())
            { return false; }

            seats[row][column].setSeatAvailability(false);
            return true;
        }
    }
}
