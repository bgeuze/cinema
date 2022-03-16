using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Interface
    {
        public static bool Login(string username, string password)
        {
            return JsonHandler.FindUser(username, password);
        }

        public static bool Register(string username, string password)
        {
            return JsonHandler.SaveUser(username, password);
        }

        public static bool NowPlayingMovies()
        {
            return JsonHandler.NowPlayingMovies();
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
    }
}
