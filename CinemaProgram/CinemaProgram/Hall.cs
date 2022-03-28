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
        //private Movie movie;
        private string time;

        public Hall(int number, Seat[][] seat)
        {
            this.hallNumber = number;
            this.seats = seat;
           // seats = new Seat[seat.GetLength(0)][];
            //for (int i = 0; i < seat.GetLength(0); i++)
            //{
             //   for (int j = 0; j < seat.GetLength(1) -1; j++)
             //       seats[i][j] = seat[i][j];
            //}
        }
        public void setRange(int row, int column, char Range)
        {
            seats[row][column].setSeatRange(Range);
        }

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