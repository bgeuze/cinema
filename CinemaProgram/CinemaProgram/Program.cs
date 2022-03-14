using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;

namespace CinemaProgram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           /* 
            //displays title & logo
            string logo = await File.ReadAllTextAsync("logo.txt");
            Console.WriteLine(logo + "\n");
           
            Console.WriteLine("Cinema School Project C#\r");
            Console.WriteLine("------------------------\n");

            //user login & registration
            ConsoleProgram.LoginRegister();

            var table = new ConsoleTable("ID", "Menu");
            table.AddRow("1", "Alle films");
            table.AddRow("2", "Alle gebruikers");
            table.Write();

            string userselection;
            userselection = Console.ReadLine();
            switch (Convert.ToInt32(userselection))
            {
                case 1:
                   // ConsoleProgram.NowPlayingMovies();
                    break;
                case 2:
                    //ConsoleProgram.AllUsers();
                    break;
            }*/
           TestCases.Start();
        }
    }
}
