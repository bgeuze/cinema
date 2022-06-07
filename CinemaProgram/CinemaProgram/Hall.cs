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
            Seat[][] seatsTemplate = new Seat[14][];

            //Create and fill a testing Hall Template
            seatsTemplate[0] = new Seat[] { new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('D'), new Seat('D') };
            seatsTemplate[1] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('D') };
            seatsTemplate[2] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('D') };
            seatsTemplate[3] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[4] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[5] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[6] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[7] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[8] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[9] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[10] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[11] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('D') };
            seatsTemplate[12] = new Seat[] { new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('D'), new Seat('D') };
            seatsTemplate[13] = new Seat[] { new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('D'), new Seat('D') };
            
            this.seats = seatsTemplate;
        }

        public void HallType2()
        {
            Seat[][] seatsTemplate = new Seat[19][];

            //Create and fill a testing Hall Template
            seatsTemplate[0] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[1] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[2] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B') };
            seatsTemplate[3] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B') };
            seatsTemplate[4] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B') };
            seatsTemplate[5] = new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('A') };
            seatsTemplate[6] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('A') };
            seatsTemplate[7] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('A'), new Seat('A') };
            seatsTemplate[8] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A') };
            seatsTemplate[9] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A') };
            seatsTemplate[10] =new Seat[] { new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A') };
            seatsTemplate[11] =new Seat[] { new Seat('A'), new Seat('A'), new Seat('B'), new Seat('B'), new Seat('A'), new Seat('A') };
            seatsTemplate[11] =new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('B'), new Seat('A'), new Seat('A') };
            seatsTemplate[12] =new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[13] =new Seat[] { new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[14] =new Seat[] { new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[15] =new Seat[] { new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[16] =new Seat[] { new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[17] =new Seat[] { new Seat('D'), new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A') };
            seatsTemplate[18] =new Seat[] { new Seat('D'), new Seat('D'), new Seat('D'), new Seat('A'), new Seat('A'), new Seat('A') };

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
        
        
        //Availability
        public bool hasFreeSeats()
        {
            bool hasSeats = false;
            foreach(Seat[] seatArray in seats)
            {
                foreach (Seat seat in seatArray)
                {
                    if (seat.seatAvailability)
                    {
                        hasSeats = true;
                    }
                }
            }

            return hasSeats;
        }

        public string freeSeatsOrdered()
        {
            int seatsA = 0;
            int seatsB = 0;
            int seatsC = 0;
            foreach(Seat[] seatArray in seats)
            {
                foreach (Seat seat in seatArray)
                {
                    if (seat.seatAvailability)
                    {
                        if (seat.seatRange.Equals('A'))
                        {
                            seatsA++;
                        }
                        if (seat.seatRange.Equals('B'))
                        {
                            seatsB++;
                        }
                        if (seat.seatRange.Equals('C'))
                        {
                            seatsC++;
                        }
                    }
                }
            }

            string str = "3rd Class Seats: " + seatsA + "| 2nd Class Seats: " + seatsB + "| 1st Class Seats: " + seatsC;
            return str;
        }
    }

    
}