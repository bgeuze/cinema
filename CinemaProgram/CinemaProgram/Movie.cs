using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Movie
    {
        private string movieName;
        private string duration;
        public Movie(string movieName, string duration)
        {
            this.movieName = movieName;
            this.duration = duration;
        }

        public string getMovieName() { return movieName;
        }
        public string getDuration() { return duration; }
    }
}
