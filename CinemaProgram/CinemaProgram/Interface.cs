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
