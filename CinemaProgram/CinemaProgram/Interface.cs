using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Interface
    {
        private ArrayList cinemas = new ArrayList();

        public static bool Login(string username, string password)
        {
            return UserJsonHandler.FindUser(username, password);
        }

        public static bool Register(string username, string password, string age)
        {
            return UserJsonHandler.SaveUser(username, password, age);
        }

        public static string GetUserId(string username)
        {
            return UserJsonHandler.GetUserId(username);
        }

        public static string GetUserRole(string username) {
            return UserJsonHandler.GetUserRole(username);
        }

        public static bool NowPlayingMovies()
        {
            return MovieJsonHandler.NowPlayingMovies();
        }

        public static bool AddReservation(string username, string userId, bool barReservation)
        {
            return MovieJsonHandler.AddReservation(username, userId, barReservation);
        }

        public static List<Reservation> UserReservations(string userId)
        {
            return MovieJsonHandler.UserReservations(userId);
        }

        internal Cinema getCinema(string v)
        {
            //return JsonHandler.getMovie(v);
            return null;
        }

        //Creates a cinema and checks if there is no duplicate
        internal void newCinema(string name, ArrayList halls)
        {
            CinemaJsonHandler.NewCinema(name, halls);
        }

        public static bool NewSchema()
        {
            return MovieJsonHandler.Schema();
        }
    }
}
