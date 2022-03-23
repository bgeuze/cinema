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
            return JsonHandler.FindUser(username, password);
        }

        public static bool Register(string username, string password)
        {
            return JsonHandler.SaveUser(username, password);
        }

        public static string GetUserId(string username)
        {
            return JsonHandler.GetUserId(username);
        }

        public static string GetUserRole(string username) {
            return JsonHandler.GetUserRole(username);
        }

        public static bool NowPlayingMovies()
        {
            return JsonHandler.NowPlayingMovies();
        }

        public static bool AddReservation(string username, string userId, bool barReservation)
        {
            return JsonHandler.AddReservation(username, userId, barReservation);
        }

        public static List<Reservation> UserReservations(string userId)
        {
            return JsonHandler.UserReservations(userId);
        }

        internal Cinema getCinema(string v)
        {
            //return JsonHandler.getMovie(v);
            return null;
        }

        //Creates a cinema and checks if there is no duplicate
        internal void createCinema(Cinema cinema)
        {
            //JsonHandler.addCinema(cinema);
        }

        public static bool NewSchema()
        {
            return JsonHandler.Schema();
        }
    }
}
