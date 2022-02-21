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
            foreach (Cinema cinema in cinemas)
            {
                if(cinema.getName() == v)
                { return cinema;}
                else { return null; }
            }
            return null;
        }

        //Creates a cinema and checks if there is no duplicate
        internal void createCinema(string v, ArrayList halls)
        {
            foreach (Cinema cin in cinemas)
            { if (cin.getName() == v) return; }    
            cinemas.Add(new Cinema(v,halls));
        }
    }
}
