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

        internal static Cinema getCinema(string v)
        {
            return null;
        }

        internal static void createCinema(string v, Hall[] halls)
        {
            
        }
    }
}
