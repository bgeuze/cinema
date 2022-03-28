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
        public static string Username;
        public static string UserId;
        public static string Role;

        public static void SetActiveUser(string username)
        {
            Username = username;
            UserId = Interface.GetUserId(username);
            Role = Interface.GetUserRole(username);
        }

        public static string GetUsername()
        {
            return Username;
        }

        public static string GetUserId()
        {
            return UserId;
        }

        public static string GetUserRole()
        {
            return Role;
        }

        public static async Task LoginRegisterAsync()
        {
            //displays title & logo
            string logo = await File.ReadAllTextAsync("logo.txt");
            Console.WriteLine(logo + "\n");

            Console.WriteLine("Cinema School Project C#\r");
            Console.WriteLine("------------------------\n");

            //Keuze om in te loggen of om aan te melden.
            Console.WriteLine("Wilt u inloggen of aanmelden?");
             string ant = Console.ReadLine();
            ant = ant.ToLower();
             
            while(ant != "inloggen" && ant != "aanmelden")
            {
                System.Console.WriteLine("Invoer incorrect, wilt u inloggen of aanmelden?");
                ant = System.Console.ReadLine();
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
                SetActiveUser(username);
                HomeScreen();
            }
            else
            {
                bool AanmeldBool = false;
                string username = "";
                string password = "";
                int age = 0;
                Console.Clear();
                while (AanmeldBool == false)
                {
                    Console.WriteLine("Voer een gebruikersnaam in.");
                    username = Console.ReadLine();
                    Console.WriteLine("Voer een wachtwoord in.");
                    password = Console.ReadLine();
                    Console.WriteLine("Bevestig uw wachtwoord.");
                    string password2 = Console.ReadLine();
                    Console.WriteLine("Wat is uw leeftijd");
                    age = int.Parse(Console.ReadLine());
                    if (password == password2)
                    {
                        AanmeldBool = true;
                        if (age < 13)
                        {
                            Console.Clear();
                            Console.WriteLine("Aanmelden gefaald, je bent te jong voor een account.");
                            AanmeldBool = false;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Aanmelden gefaald, wachtwoorden komen niet overheen.");
                        if (age < 13)
                        {
                            Console.Clear();
                            Console.WriteLine("Aanmelden gefaald, je bent te jong voor een account.");

                        }
                    }
                }
                while (Interface.Register(username, password, age.ToString()) != true)
                {
                    Console.WriteLine("Registreren gefaald, probeer het opnieuw.");
                    Console.WriteLine("Voer een gebruikersnaam in.");
                    username = Console.ReadLine();
                    Console.WriteLine("Voer een wachtwoord in.");
                    password = Console.ReadLine();
                }
                SetActiveUser(username);
                HomeScreen();
            }
        }

        public static void addMovie()
        {
            string movieTitle;
            int movieMinuten;
            string movieRelease;
            string movieDescription;
            Console.WriteLine("Wat is de naam van de film die u wilt toevoegen?");
            movieTitle = Console.ReadLine();
            Console.WriteLine("Hoelang duurt de film in minuten?");
            movieMinuten = int.Parse(Console.ReadLine());
            Console.WriteLine("Op welke datum komt de film uit?");
            movieRelease = Console.ReadLine();
            Console.WriteLine("Geef een beschrijving van de film.");
            movieDescription = Console.ReadLine();
        }

        public static void AddReservation()
        {
            bool barReservation;
            string ans;

            Console.WriteLine("Wilt u een plek aan de bar reserveren?");
            var table = new ConsoleTable("", "");
            table.AddRow("1", "Ja");
            table.AddRow("2", "Nee");
            table.Write();

            ans = Console.ReadLine();

            if (ans == "1")
            {
                barReservation = true;
            }
            else
            {
                barReservation = false;
            }

            Interface.AddReservation(GetUsername(), GetUserId(), barReservation);
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

        public static bool UserReservations()
        {
            var result = Interface.UserReservations(GetUserId());

            var table = new ConsoleTable("ID", "Bar", "Naam", "Datum");

            foreach (var reservation in (dynamic)result)
            {
                table.AddRow($"{reservation.Id}", $"{reservation.BarReservation}", $"{reservation.Name}", $"{reservation.CreatedDateTime}");
            }

            table.Write();

            return true;
        }
        
        public static void AllUsers()
        {
            var filePath = "user.json";
            //read all json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var users = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                    ?? new List<User>();

            var table = new ConsoleTable("ID", "Gebruikersnaam", "Wachtwoord", "Leeftijd", "Rol", "Account sinds");

            foreach (var user in (dynamic)users)
            {
                table.AddRow($"{user.Id}", $"{user.Username}", $"{user.Password}", $"{user.Age}", $"{user.Role}", $"{user.CreatedDateTime}");
            }

            table.Write();
        }

        public static void NewSchema()
        {
            Interface.NewSchema();
        }

        public static void HomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Hallo, " + GetUsername() + " uw rol is " + GetUserRole());

            string userselection;
            var table = new ConsoleTable("ID", "Menu");

            switch (GetUserRole())
            {
                case "Admin":
                    table.AddRow("1", "Alle films");
                    table.AddRow("2", "Alle gebruikers");
                    table.AddRow("3", "Nieuwe reservering");
                    table.AddRow("4", "Mijn reserveringen");
                    table.AddRow("5", "Nieuw schema");
                    table.Write();

                    userselection = Console.ReadLine();

                    switch (Convert.ToInt32(userselection))
                    {
                        case 1:
                            NowPlayingMovies();
                            break;
                        case 2:
                            AllUsers();
                            break;
                        case 3:
                            AddReservation();
                            break;
                        case 4:
                            UserReservations();
                            break;
                        case 5:
                            NewSchema();
                            break;
                    }
                    break;

                case "User":
                    table.AddRow("1", "Alle films");
                    table.AddRow("2", "Nieuwe reservering");
                    table.AddRow("3", "Mijn reserveringen");
                    table.Write();

                    userselection = Console.ReadLine();

                    switch (Convert.ToInt32(userselection))
                    {
                        case 1:
                            NowPlayingMovies();
                            break;
                        case 2:
                            AddReservation();
                            break;
                        case 3:
                            UserReservations();
                            break;
                    }
                    break;
            }
        }
    }
}
