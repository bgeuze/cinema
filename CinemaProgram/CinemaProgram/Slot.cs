using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Slot
    {
        private Movie _movie;
        private Seat[][] movieSeats;
        private Hall movieHall;
        private String startTime;
        private String endTime;

        public Slot(Movie movie, Seat[][] Seats, Hall hall,String startTime,String endTime)
        { 
            this._movie = movie;
            this.movieSeats = Seats;
            this.movieHall = hall;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public Movie GetMovie() { return _movie; }
        public Seat[][] GetMovieSeats() { return movieSeats; }
        public Hall GetMovieHall() { return movieHall; }
        public String GetStartTime() { return startTime; }
        public String GetEndTime() { return endTime; }

    }
}
