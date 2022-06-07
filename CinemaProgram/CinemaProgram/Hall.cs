using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    public class Hall
    {
        public int hallNumber;
        public Seat[][] seats;
        //private Movie movie;
        public string time;

        public Hall(int number, int hallType)
        {
            this.hallNumber = number;
            if(hallType == 1) { HallType1(); }
            if (hallType == 2) { HallType2(); }
            if (hallType == 3) { HallType3(); }
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

        public void HallType1()
        {
            Seat[][] seatsTemplate = new Seat[6][];

            //Create and fill a testing Hall Template
            seatsTemplate[0] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[1] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A') };
            seatsTemplate[2] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('A') };
            seatsTemplate[3] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('A') };
            seatsTemplate[4] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A') };
            seatsTemplate[5] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };

            this.seats = seatsTemplate;
        }

        public void HallType2()
        {
            Seat[][] seatsTemplate = new Seat[6][];

            //Create and fill a testing Hall Template
            seatsTemplate[0] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[1] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A') };
            seatsTemplate[2] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('A') };
            seatsTemplate[3] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('A') };
            seatsTemplate[4] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A') };
            seatsTemplate[5] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };

            this.seats = seatsTemplate;
        }

        public void HallType3()
        {
            Seat[][] seatsTemplate = new Seat[6][];

            //Create and fill a testing Hall Template
            seatsTemplate[0] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[1] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[2] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[3] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[4] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[5] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'),new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };

            this.seats = seatsTemplate;
        }
    }

    
}