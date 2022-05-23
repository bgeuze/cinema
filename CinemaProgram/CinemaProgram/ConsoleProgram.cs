using System;
using System.Collections;
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
        public static DateTime Birthday;
        public static void SetActiveUser(string username)
        {
            Username = username;
            UserId = Interface.GetUserId(username);
            Role = Interface.GetUserRole(username);
            Birthday = Interface.GetUserLeeftijd(username);
        }

        public static string GetUsername()
        {
            return Username;
        }

        public static DateTime GetUserLeeftijd()
        {
            return Birthday;
        }
        public static string GetUserId()
        {
            return UserId;
        }

        public static string GetUserRole()
        {
            return Role;
        }
        public static int getUserAge(DateTime birthday)
        {

            var today = DateTime.Today;


            var age = today.Year - birthday.Year;


            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
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

            while (ant != "inloggen" && ant != "aanmelden")
            {
                Console.WriteLine("Invoer incorrect, wilt u inloggen of aanmelden?");
                ant = Console.ReadLine();
            }
            if (ant == "inloggen")
            {
                Console.Clear();
                string username = null;
                var pass = "";

                while (Interface.Login(username, pass) != true)
                {
                    Console.WriteLine("Wat is uw gebruikersnaam?");
                    username = Console.ReadLine();
                    Console.WriteLine("Wat is uw wachtwoord?");
                    pass = string.Empty;
                    ConsoleKey key;
                    do
                    {
                        var keyInfo = Console.ReadKey(intercept: true);
                        key = keyInfo.Key;

                        if (key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            Console.Write("\b \b");
                            pass = pass[0..^1];
                        }
                        else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            pass += keyInfo.KeyChar;
                        }
                    } while (key != ConsoleKey.Enter);
                    if (Interface.Login(username, pass) != true)
                    {
                        Console.Clear();
                        Console.WriteLine("Inloggen gefaald, probeer het opnieuw.");
                        username = null;
                        pass = "";
                    };
                }
                SetActiveUser(username);
                HomeScreen();
            }
            else
            {
                bool AanmeldBool = false;
                string username = "";
                string password = "";
                DateTime birthday = new DateTime();
                Console.Clear();
                while (AanmeldBool == false)
                {
                    Console.WriteLine("Voer een gebruikersnaam in.");
                    username = Console.ReadLine();
                    Console.WriteLine("Voer een wachtwoord in.");
                    password = Console.ReadLine();
                    Console.WriteLine("Bevestig uw wachtwoord.");
                    string password2 = Console.ReadLine();
                    Console.WriteLine("Wat is uw Geboortedatum? DD/MM/YYYY");
                    birthday = DateTime.Parse(Console.ReadLine());
                    if (password == password2)
                    {
                        AanmeldBool = true;
                        if (getUserAge(birthday) < 13)
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
                        if (getUserAge(birthday) < 13)
                        {
                            Console.Clear();
                            Console.WriteLine("Aanmelden gefaald, je bent te jong voor een account.");

                        }
                    }
                }
                while (Interface.Register(username, password, birthday) != true)
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

            GoToHome();
        }

        public static void AddReservation()
        {
            bool[] Test = { true, false };
            Console.WriteLine("Welke Film wilt u kijken?");
            int ans2 = int.Parse(Console.ReadLine());
            int minAge = 13;
            int gekozenFilmIndex = ans2 - 1;
            if (Test[gekozenFilmIndex] == true)
            {
                minAge = 16;
            };
            if (getUserAge(GetUserLeeftijd()) >= minAge)
            {
                Console.WriteLine("Oud Genoeg");
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

                Interface.AddReservation(GetUsername(), GetUserId(), barReservation, SeatSelectionScreen());
                GoToHome();
            }
            else
            {
                
                Console.WriteLine("Je bent te jong om deze film bij te wonen.");
                HomeScreen();
            };

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

            GoToHome();

        }

        public static bool UserReservations()
        {
            var result = Interface.UserReservations(GetUserId());

            var table = new ConsoleTable("ID", "Bar", "Stoel", "Naam", "Datum");

            foreach (var reservation in (dynamic)result)
            {
                string seattext = "";
                foreach (var seat in reservation.SeatList)
                {
                    seattext += seat.SeatIndex + ", ";
                }

                seattext = seattext.Remove(seattext.Length - 2);
                table.AddRow($"{reservation.Id}", $"{reservation.BarReservation}", seattext, $"{reservation.Name}", $"{reservation.CreatedDateTime}");
            }

            table.Write();

            var table2 = new ConsoleTable("", "");
            table2.AddRow("1", "Verwijder reservering");
            table2.AddRow("2", "Terug naar home");
            table2.Write();

            string ans = Console.ReadLine();

            if (ans == "1")
            {
                RemoveReservation();
            }
            else if (ans == "2")
            {
                HomeScreen();
            }

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

            var table = new ConsoleTable("ID", "Gebruikersnaam", "Wachtwoord", "Leeftijd", "Geboortedatum", "Rol", "Account sinds");

            foreach (var user in (dynamic)users)
            {
                table.AddRow($"{user.Id}", $"{user.Username}", $"{user.Password}", $"{ConsoleProgram.getUserAge(user.Birthday)}", $"{user.Birthday.ToShortDateString()}", $"{user.Role}", $"{user.CreatedDateTime}");
            }

            table.Write();

            GoToHome();
        }

        public static void NewSchema()
        {
            Interface.NewSchema();
        }

        public static void GoToHome()
        {
            Console.WriteLine("\n Press 0 to go back to the menu.");
            string ans = Console.ReadLine();
            if (ans == "0")
            {
                HomeScreen();
            }
        }

        public static void RemoveReservation()
        {
            Console.WriteLine("Geef het reserverings ID");
            string reservationID = Console.ReadLine();
            Interface.RemoveReservation(reservationID);
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

        public static Seat[] SeatSelectionScreen()
        {
            int seatAmount = 2;
            ArrayList halls = new ArrayList();
            Seat[][] seats = new Seat[6][];

            //Unorganized mess
            int pos1 = -1;
            int pos2 = -1;
            //Create and fill a testing Hall Template
            seats[0] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };
            seats[1] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A') };
            seats[2] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('A') };
            seats[3] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('C'), new Seat('C'), new Seat('B'), new Seat('A') };
            seats[4] = new Seat[] { new Seat('A'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('B'), new Seat('A') };
            seats[5] = new Seat[] { new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A'), new Seat('A') };

            Hall hall = new Hall(1, seats);
            halls.Add(hall);

            Hall hall2 = new Hall(2, seats);
            halls.Add(hall2);

            //Temp seat array for display purposes
            Seat[][] tseats = hall.getSeats();
            tseats[2][4].setSeatAvailability(false);
            tseats[1][2].setSeatAvailability(false);
            tseats[1][3].setSeatAvailability(false);
            List<Seat> chosenOnes = new List<Seat>();
            //Lets the user select seats untill all are selected
            while (seatAmount > 0)
            {
                Console.Clear();
                Console.Write("  ");
                //Array position to letter
                for (int a = 0; a < tseats[0].Length; a++)
                {
                    Console.Write("  ");
                    Console.Write(a+1);
                    /*aswitch (a + 1)
                    {
                        case 1:
                            Console.Write("A");
                            break;
                        case 2:
                            Console.Write("B");
                            break;
                        case 3:
                            Console.Write("C");
                            break;
                        case 4:
                            Console.Write("D");
                            break;
                        case 5:
                            Console.Write("E");
                            break;
                        case 6:
                            Console.Write("F");
                            break;
                        case 7:
                            Console.Write("G");
                            break;
                    }*/
                }
                Console.WriteLine();

                for (int i = 0; i < tseats.Length; i++)
                {
                    Console.Write(i + 1 + "  ");
                    for (int j = 0; j < tseats[i].Length; j++)
                    {
                        //Changes the character color based upon the availability
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (tseats[i][j].getSeatAvailability() == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }

                        char seatType = tseats[i][j].getSeatRange();
                        switch (seatType)
                        {
                            //Changes the background color of a seat based upon the seatRange variable
                            case 'A':
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 'B':
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                break;
                            case 'C':
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;
                        }

                        //Console.ForegroundColor = ConsoleColor.DarkBlue;
                        //If a seat has been selected before and it is this seat in the array give it a nice lil colour
                        if (pos1 >= 0 && pos2 >= 0)
                        {
                            if (tseats[i][j] == tseats[pos1][pos2])
                            {
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            }
                        }

                        Console.Write(" ■ "); //tseats[i][j].seatRange);

                    }
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                }
                if (seatAmount > 1)
                {
                    Console.WriteLine("Please enter seat sir, you have " + seatAmount + " choice left: ");
                }
                /*For everything*/
                else // there is mastercard
                {
                    Console.WriteLine("Please enter seat sir, you have " + seatAmount + " choices left: ");
                }

                Console.WriteLine("You will select a seat number:");
                string? seatChoice1 = Console.ReadLine();
                Console.WriteLine("You will select a seat Leter:");
                string? seatChoice2 = Console.ReadLine();
                Console.WriteLine("Are you sure you want seat(y/n): " + seatChoice1 + seatChoice2);

                string? command = Console.ReadLine();
                if (command != null && command.ToLower().Equals("n"))
                {
                    Console.WriteLine("Cry me a river");
                }
                if (command != null && command.ToLower().Equals("y"))
                {
                    seatAmount--;
                    //Maybe remove null warning supressor... Maybe don't...
                    pos1 = Int32.Parse(seatChoice1!) - 1;
                    pos2 = Int32.Parse(seatChoice2!) - 1;//Interface.ToNumberPosition(seatChoice2!.ToUpper());
                    chosenOnes.Add(tseats[pos1][pos2]);
                    tseats[pos1][pos2].setSeatAvailability(false);
                    tseats[pos1][pos2].SeatIndex = "R: " + pos1.ToString() + " S:" + pos2.ToString();
                }
            }

            return Interface.ArrayListToArray(chosenOnes);
        }
    }
}
