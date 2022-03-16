using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;

namespace CinemaProgram
{
    internal class ConsoleProgram
    {
        private static string ant;

        public static async Task LoginRegisterAsync()
        {
            //displays title & logo
            string logo = await File.ReadAllTextAsync("logo.txt");
            Console.WriteLine(logo + "\n");

            Console.WriteLine("Cinema School Project C#\r");
            Console.WriteLine("------------------------\n");

            //Keuze om in te loggen of om aan te melden.
            Console.WriteLine("Wilt u inloggen of aanmelden?");
            ant = Console.ReadLine();
            
            while(ant != "inloggen" && ant != "aanmelden")
            {
                Console.WriteLine("Invoer incorrect, wilt u inloggen of aanmelden?");
                ant = Console.ReadLine();
            }
            if(ant == "inloggen")
            {
                Console.Clear();
                Console.WriteLine("Wat is uw gebruikersnaam?");
                string username = Console.ReadLine();
                Console.WriteLine("Wat is uw wachtwoord?");
                string password = Console.ReadLine();

                while (Interface.Login(username,password) != true)
                {
                    Console.WriteLine("Inloggen gefaald, probeer het opnieuw.");
                    Console.WriteLine("Wat is uw gebruikersnaam?");
                    username = Console.ReadLine();
                    Console.WriteLine("Wat is uw wachtwoord?");
                    password = Console.ReadLine();
                }

                HomeScreen();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Voer een gebruikersnaam in.");
                string username = Console.ReadLine();
                Console.WriteLine("Voer een wachtwoord in.");
                string password = Console.ReadLine();

                while (Interface.Register(username, password) != true)
                {
                    Console.WriteLine("Registreren gefaald, probeer het opnieuw.");
                    Console.WriteLine("Voer een gebruikersnaam in.");
                    username = Console.ReadLine();
                    Console.WriteLine("Voer een wachtwoord in.");
                    password = Console.ReadLine();
                }

                HomeScreen();
            }
        }

        public static void NowPlayingMovies()
        {
            Console.WriteLine("Hieronder vindt u een lijst met films die nu in onze bisocoop draaien.");
            //fill json with all nowplaying movies
            Interface.NowPlayingMovies();

            var filePath = "movies.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData)
                                    ?? new List<Movie>();

            var table = new ConsoleTable("ID", "Title", "Release Date");

            foreach (var movie in (dynamic)movieList)
            {
                table.AddRow($"{movie.Id}", $"{movie.Title}", $"{movie.ReleaseDate}");
            }

            table.Write();
        }

        public static void AllUsers()
        {
            var filePath = "user.json";
            //read all json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var users = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                    ?? new List<User>();

            var table = new ConsoleTable("ID", "Gebruikersnaam", "Wachtwoord", "Rol", "Account sinds");

            foreach (var user in (dynamic)users)
            {
                table.AddRow($"{user.Id}", $"{user.Username}", $"{user.Password}", $"{user.Role}", $"{user.CreadtedDateTime}");
            }

            table.Write();
        }

        public static void HomeScreen()
        {
            Console.Clear();

            var table = new ConsoleTable("ID", "Menu");
            table.AddRow("1", "Alle films");
            table.AddRow("2", "Alle gebruikers");
            table.Write();

            string userselection;
            userselection = Console.ReadLine();
            switch (Convert.ToInt32(userselection))
            {
                case 1:
                    NowPlayingMovies();
                    break;
                case 2:
                    AllUsers();
                    break;
            }
        }
    }
}
