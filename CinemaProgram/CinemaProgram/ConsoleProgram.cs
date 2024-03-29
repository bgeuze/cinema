﻿using System;
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
        private static Cinema cinema;
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
                    birthday = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
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
        
        //Lets the user make a reservation
        public static void AddReservation()
        {
            NowPlayingMovies();
            Console.WriteLine("Geef het ID van de film die u wilt kijken.");
            
            int ans2 = int.Parse(Console.ReadLine());
            Interface.NowPlayingMovies();

            var filePath = "movies.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData) ?? new List<Movie>();

            Movie gekozenFilm = null;
            foreach (var movie in (dynamic)movieList)
            {
                if (movie.Id == ans2)
                {
                    gekozenFilm = movie;
                    break;
                }
            }

            int minAge = 13;
            int gekozenFilmIndex = ans2 - 1;
            if (gekozenFilm.Adult == true)
            {
                minAge = 16;
            };
            if (getUserAge(GetUserLeeftijd()) >= minAge)
            {
                var filePath2 = "filmsforschema.json";
                //read existing json data
                var jsonData2 = File.ReadAllText(filePath2);
                //de-serialize to object or create new list
                var MovieList2 = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData2)
                                      ?? new List<FilmsforSchema>();
                var table2 = new ConsoleTable();
                var GekozenMovieTijd = "";
                foreach (var film2 in (dynamic)MovieList2) if (film2.MovieTitle == gekozenFilm.Title)
                {
                    table2 = new ConsoleTable($"Hal {film2.HallNumber}", "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag");
                    GekozenMovieTijd = film2.StartTime;
                }
                foreach (var film2 in (dynamic)MovieList2) if (film2.MovieTitle == gekozenFilm.Title)
                {
                        if (film2.MovieTitle.Length > 25)
                        {
                            film2.MovieTitle = film2.MovieTitle.Substring(0, 22);
                            film2.MovieTitle = film2.MovieTitle + "...";
                        }
                        table2.AddRow($"{film2.StartTime}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}");
                        


                        if (film2.StartTime == "10:00")
                    {
                             

                        table2.AddRow($"17:00", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}");

                       

                        

                        

                    }
                    if (film2.StartTime == "12:00")
                    {
                        table2.AddRow($"19:00", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}");
                    }
                    if (film2.StartTime == "14:00")
                    {
                        table2.AddRow($"21:00", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}", $"{film2.MovieTitle}");
                    }


                }
                table2.Write();
                bool tijdenBool = false;
                string GekozenDag = "";
                string GekozenTijd = "";
                while (tijdenBool == false)
                {
                    Console.WriteLine("Op welke dag wilt u de film kijken?");
                    GekozenDag = Console.ReadLine();
                    Console.WriteLine("Op welke tijd wilt u de film kijken?");
                    GekozenTijd = Console.ReadLine();
                    if (GekozenMovieTijd == "10:00")
                    {
                        if (GekozenTijd == "10:00" || GekozenTijd == "17:00")
                        {
                            tijdenBool = true;
                        }
                        else
                        {
                            Console.WriteLine("Er is geen film op deze tijd beschikbaar.");
                        }
                    }
                    else if (GekozenMovieTijd == "12:00")
                    {
                        if (GekozenTijd == "12:00" || GekozenTijd == "19:00")
                        {
                            tijdenBool = true;
                        }
                        else
                        {
                            Console.WriteLine("Er is geen film op deze tijd beschikbaar.");
                        }
                    }
                    else if (GekozenMovieTijd == "14:00")
                    {
                        if (GekozenTijd == "14:00" || GekozenTijd == "21:00")
                        {
                            tijdenBool = true;
                        }
                        else
                        {
                            Console.WriteLine("Er is geen film op deze tijd beschikbaar.");
                        }
                    }
                }
                Console.WriteLine($"De gekozen tijd is {GekozenTijd} op {GekozenDag}");
                
                bool barReservation = false;
                string ans;
                //Gets the hall from the chosen movie using the schedule list 
                Hall hall = new Hall(2,2);//new Hall(2, 2);
                foreach (var film in (dynamic)MovieList2)
                {
                    if (film.MovieTitle == gekozenFilm.Title)
                    {
                        hall = film.hallObject;
                        if(!hall.hasFreeSeats())
                        {
                            Console.WriteLine("Helaas deze film is al volgeboekt klik op een knop om terug te gaan naar het hoofdmenu...");
                            Console.ReadLine();
                            HomeScreen();
                        }
                        else
                        {
                            Console.WriteLine("Deze plekken zijn nog beschikbaar: " + hall.freeSeatsOrdered());
                        }
                    }
                }
                //TODO: Create cinema or load it in from the JSON
                
                Hall[] halls = new Hall[1];
                halls[0] = hall;
                cinema = new Cinema("HELLO");
                //cinema.addHall(hall);
                cinema.bars = new Bar(40, 2);
                //Seat selection and amount of people input
                Console.WriteLine("Voor hoeveel mensen wilt u reserveren?");
                int amount = int.Parse(Console.ReadLine());
                if (cinema.getBar().Available)
                {
                Console.WriteLine("Wilt u een plek aan de bar reserveren?");
                var table = new ConsoleTable("", "");
                table.AddRow("1", "Ja");
                table.AddRow("2", "Nee");
                table.Write();

                ans = Console.ReadLine();

                if (ans == "1")
                {
                    barReservation = true;
                    //TODO: Change cinema to actual cinema
                    cinema.getBar().assignTable(amount,1500, "");
                } 
                }
                else
                {
                    Console.WriteLine("Excuses de Bar is op dit moment niet beschikbaar." +
                                      "\nKlik op een toets om door te gaan...");
                    Console.ReadLine();
                }

                //TODO: Remove hallnumber 2 for hallnumber of selected moviea ANd bind to cinema or something
                //hall = new Hall(2, 2);
                Seat[] seats = SeatSelectionScreen(amount, hall);
                //Calculates Total price and waits for input of user to continue
                double totalCost = Interface.SeatPriceCalculation(seats);
                Console.WriteLine("Totale kosten: " + totalCost + ",-");
                GekozenDag = GekozenDag.ToLower();
                int daysFromMonday = 0;
                if (GekozenDag == "maandag")
                {
                    daysFromMonday = 0;
                }
                else if (GekozenDag == "dinsdag")
                {
                    daysFromMonday = 1;
                }
                else if (GekozenDag == "woensdag")
                {
                    daysFromMonday = 2;
                }
                else if (GekozenDag == "donderdag")
                {
                    daysFromMonday = 3;
                }
                else if (GekozenDag == "vrijdag")
                {
                    daysFromMonday = 4;
                }
                else if (GekozenDag == "zaterdag")
                {
                    daysFromMonday = 5;
                }
                else
                {
                    daysFromMonday = 6;
                }

                System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek + 7 + daysFromMonday;
                DateTime playDateTime = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - fdow));

                string playDateString = playDateTime.ToString();
                string playDate = playDateString.Remove(playDateString.Length - 12);

                //TODO: Seat still has to be set on unavailable in the Json/
                
                Interface.AddReservation(GetUsername(), GetUserId(), barReservation, seats, gekozenFilm.Title, totalCost, playDate, GekozenTijd);
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
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData) ?? new List<Movie>();

            var table = new ConsoleTable("ID", "Titel", "Release Datum");

            foreach (var movie in (dynamic)movieList)
            {
                table.AddRow($"{movie.Id}", $"{movie.Title}", $"{movie.ReleaseDate}");
            }

            table.Write();
        }

        public static bool AllReservations()
        {
            var result = Interface.AllReservations();

            var table = new ConsoleTable("ID", "Film", "Datum", "Tijd", "Bar", "Stoel", "Naam", "Reservatie Datum");

            foreach (var reservation in (dynamic)result)
            {
                string seattext = "";
                string barreservation = "";
                foreach (var seat in reservation.SeatList)
                {
                    seattext += seat.SeatIndex + ", ";
                }

                seattext = seattext.Remove(seattext.Length - 2);

                if (reservation.BarReservation == true)
                {
                    barreservation = "Ja";
                }
                else
                {
                    barreservation = "Nee";
                }

                table.AddRow($"{reservation.Id}", $"{reservation.FilmTitle}", $"{reservation.PlayDate}", $"{reservation.PlayTime}", barreservation, seattext, $"{reservation.Name}", $"{reservation.CreatedDateTime}");
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

        public static bool UserReservations()
        {
            var result = Interface.UserReservations(GetUserId());

            var table = new ConsoleTable("ID", "Film", "Datum", "Tijd", "Bar", "Stoel", "Naam", "Reservatie Datum");

            foreach (var reservation in (dynamic)result)
            {
                string seattext = "";
                string barreservation = "";
                foreach (var seat in reservation.SeatList)
                {
                    seattext += seat.SeatIndex + ", ";
                }

                seattext = seattext.Remove(seattext.Length - 2);

                if (reservation.BarReservation == true)
                {
                    barreservation = "Ja";
                }
                else
                {
                    barreservation = "Nee";
                }

                table.AddRow($"{reservation.Id}", $"{reservation.FilmTitle}", $"{reservation.PlayDate}", $"{reservation.PlayTime}", barreservation, seattext, $"{reservation.Name}", $"{reservation.CreatedDateTime}");
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
            var users = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();

            var table = new ConsoleTable("ID", "Gebruikersnaam", "Wachtwoord", "Leeftijd", "Geboortedatum", "Rol", "Account sinds");

            foreach (var user in (dynamic)users)
            {
                table.AddRow($"{user.Id}", $"{user.Username}", $"{user.Password}", $"{ConsoleProgram.getUserAge(user.Birthday)}", $"{user.Birthday.ToShortDateString()}", $"{user.Role}", $"{user.CreatedDateTime}");
            }

            table.Write();
            Console.WriteLine("\n\nWilt u de role van iemand aanpassen?");
            Console.WriteLine("type ja of nee.");
            string answer = Console.ReadLine();
            if (answer == "ja")
            {
                UserJsonHandler.ChangeUserRole();
            }
            
            GoToHome();
        }

        public static void GoToHome()
        {
            Console.WriteLine("\n Druk op 0 om terug te gaan naar het menu.");
            string ans = Console.ReadLine();
            if (ans == "0")
            {
                Console.Clear();
                HomeScreen();
            } else
            {
                Console.WriteLine("\n Je hebt het verkeerde nummer ingevuld.");
                GoToHome();
            }
        }

        public static void RemoveReservation()
        {
            Console.WriteLine("Geef het reserverings ID");
            string reservationID = Console.ReadLine();

            Interface.RemoveReservation(reservationID, GetUsername());
        }
        
        //Display filmSchema
        public static void HallsSchema()
        {

            var filePath = "filmsforschema.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var MovieList = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData)
                                  ?? new List<FilmsforSchema>();

            int hallAmount = 0;
            foreach (var hallnum in (dynamic)MovieList)
            {
                int haln = int.Parse($"{hallnum.HallNumber}");
                if (hallAmount < haln)
                {
                    hallAmount = haln;
                }
            }

            for (int i = 1; i < hallAmount+1; i++)
            {
                Console.WriteLine($"Alle films in zaal {i}.\n");
                var table = new ConsoleTable("Tijd", "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag");
                int time = 10;
                foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == i.ToString())
                {
                    string f = $"{film.MovieTitle}";
                    if (f.Length > 25)
                    {
                        f = f.Substring(0, 22);
                        f = f + "...";
                    }
                        
                    string starttime = film.StartTime;
                    table.AddRow(starttime, f, f, f, f, f, f, f);
                    time += 2;
                }
                foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == i.ToString())
                {
                    string f = $"{film.MovieTitle}";
                    string starttime = film.StartTime;
                    if (f.Length > 25)
                    {
                        f = f.Substring(0, 22);
                        f = f + "...";
                    }

                    string text = film.StartTime;
                    string uren = text.Substring(0, text.LastIndexOf(':'));
                    string minuten = text.Substring(text.LastIndexOf(':') + 1);
                    int hours = int.Parse(uren) + 7;
                    string tijd = hours + ":" + minuten;
                    table.AddRow(tijd, f, f, f, f, f, f, f);
                    time += 2;
                }
                table.Write();
            }

        }

        public static void Movietime()
        {
            var filePath = "filmsforschema.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var MovieList = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData)
                            ?? new List<FilmsforSchema>();

            var table = new ConsoleTable("ID", "Film");
            int i = 0;
            foreach (var film in (dynamic)MovieList) if (int.Parse(film.HallNumber) > 0)
            {
                table.AddRow(i, film.MovieTitle);
                i++;
            }
            table.Write();
            Console.WriteLine("\nTyp het nummer van de film waar u informatie van wilt.");
            string movieselection = Console.ReadLine();
            if (int.Parse(movieselection) > i-1 || int.Parse(movieselection) < 0){
                Console.Clear();
                Console.WriteLine("Dit nummer is niet van toepassing geef een ander nummer.");
                Movietime();
            } else
            {
                Console.WriteLine(MovieList[int.Parse(movieselection)].MovieTitle);
                string text = MovieList[int.Parse(movieselection)].StartTime;
                string uren = text.Substring(0, text.LastIndexOf(':'));
                string minuten = text.Substring(text.LastIndexOf(':') + 1);
                int hours = int.Parse(uren) + 7;
                string tijd = hours + ":" + minuten;
                Console.WriteLine($"De film draait om {MovieList[int.Parse(movieselection)].StartTime} en om {tijd}");
                Console.WriteLine($"De film draait in zaal {MovieList[int.Parse(movieselection)].HallNumber}\n");
            }
            jsonData = JsonConvert.SerializeObject(MovieList);
            File.WriteAllText(filePath, jsonData);
        }

        public static void editMovieOnSchema()
        {
             var filePath = "filmsforschema.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var MovieList = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData)
                                  ?? new List<FilmsforSchema>();


            jsonData = JsonConvert.SerializeObject(MovieList);
            File.WriteAllText(filePath, jsonData);

            string userselection;
            var table = new ConsoleTable("ID", "Zaal");

            int hallAmount = 0;
            foreach (var hallnum in (dynamic)MovieList)
            {
                int haln = int.Parse($"{hallnum.HallNumber}");
                if (hallAmount < haln)
                {
                    hallAmount = haln;
                }
            }
            for (int i = 1; i < hallAmount + 1; i++)
            {
                table.AddRow(i, $"Bewerk films uit zaal {i}");

            }
            table.Write();

            userselection = Console.ReadLine();

            int count1 = 1;
            foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == userselection && int.Parse(film.HallNumber) > 0) if (int.Parse(userselection) < hallAmount || int.Parse(userselection) > 0)
            {
                Console.WriteLine(count1 + ": " + $"{film.MovieTitle}");
                count1++;
            } else
            {
                Console.Clear();
                Console.WriteLine("De ingegeven input klopt niet.");
                editMovieOnSchema();
            }

            Console.WriteLine("Voer het nummer in van de film die u wilt wijzigen.");
            string movieselection = Console.ReadLine();
            int count2 = 1;
            foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == userselection) if (int.Parse(userselection) < count2 || int.Parse(userselection) > 0)
                    {
                    if (count2.ToString() == movieselection)
                    {
                        Console.WriteLine($"Weet u zeker dat u deze film wilt wijzigen: {$"{film.MovieTitle}"}?");
                    }
                    count2++;
                }
                else
                {
                    Console.WriteLine("De ingegeven input klopt niet.");
                    editMovieOnSchema();
                }

            Console.WriteLine("\nVul Ja of Nee in.");
            string YesOrNo = Console.ReadLine();
            if (YesOrNo == "ja" || YesOrNo == "Ja") {
                Console.WriteLine("\nVoer de naam van de nieuwe film in.");
            } else if (YesOrNo == "nee" || YesOrNo == "Nee") {
                printSchema();
            }
            else
            {
                Console.WriteLine("Deze input klopt niet");
                editMovieOnSchema();
            }

            string newMovie = Console.ReadLine();
            Console.WriteLine("\nHoelaat draait de film voor het eerst op de dag?");
            Console.WriteLine("Zet de tijd neer als volgt --:--, - stelt een nummer voor.");
            string newTime = Console.ReadLine();

            string uren = newTime.Substring(0, newTime.LastIndexOf(':'));
            string minuten = newTime.Substring(newTime.LastIndexOf(':') + 1);
            int count = 1;
            if(uren.Length == 1)
            {
                uren = "0" + uren;
                newTime = uren + ":" + minuten;
            }

            foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == userselection)
            {
                if (count.ToString() == movieselection)
                {
                    string oldmovie = film.MovieTitle;
                    Console.WriteLine($"De oude film is {oldmovie} en de nieuwe is {newMovie}");
                    film.MovieTitle = newMovie;
                    film.StartTime = newTime;
                }
                count++;
                    
            }
            jsonData = JsonConvert.SerializeObject(MovieList);
            File.WriteAllText(filePath, jsonData);
        }

        public static void AddHall()
        {
            var filePath = "filmsforschema.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var MovieList = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData)
                                  ?? new List<FilmsforSchema>();

            int hallAmount = 0;
            foreach (var hallnum in (dynamic)MovieList)
            {
                int haln = int.Parse($"{hallnum.HallNumber}");
                if (hallAmount < haln)
                {
                    hallAmount = haln;
                }
            }
            string tijduren = "10";
            string tijdminuten = "00";
            for (int i = 0; i < 3; i++)
            {
                MovieList.Add(new FilmsforSchema((hallAmount + 1).ToString(), "Plaatshouder tekst", tijduren + ":" + tijdminuten, new Hall(hallAmount +1, hallAmount +1)));
                tijduren = (int.Parse(tijduren) + 2).ToString();
            }

            Console.WriteLine($"U heeft zaal {hallAmount + 1} toegevoegd.");

            jsonData = JsonConvert.SerializeObject(MovieList);
            File.WriteAllText(filePath, jsonData);
        }
        
        public static void DeleteHall()
        {
            var filePath = "filmsforschema.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var MovieList = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData)
                                  ?? new List<FilmsforSchema>();
            
            int hallAmount = 0;
            foreach (var hallnum in (dynamic)MovieList)
            {
                int haln = int.Parse($"{hallnum.HallNumber}");
                if (hallAmount < haln)
                {
                    hallAmount = haln;
                }
            }
            Console.WriteLine($"Weet u het zeker dat u zaal {hallAmount} wilt verwijderen?");
            Console.WriteLine("Type Ja of Nee");

            int minHall = -1;
            foreach (var hallnum in (dynamic)MovieList)
            {
                int haln = int.Parse($"{hallnum.HallNumber}");
                if (minHall > haln)
                {
                    minHall = haln;
                }
            }
            string ans = Console.ReadLine();
            if (ans == "Ja" || ans == "ja")
            {
                foreach (var film in (dynamic)MovieList) if (int.Parse($"{film.HallNumber}") == hallAmount)
                    {
                        film.HallNumber = (minHall-1).ToString();
                    }
                    else
                    {
                    }
                Console.WriteLine($"U heeft zaal {hallAmount} verwijderd");
            }
            jsonData = JsonConvert.SerializeObject(MovieList);
            File.WriteAllText(filePath, jsonData);
        }
        public static void HallOptions()
        {
            var table = new ConsoleTable("1", "Zaal Toevoegen");
            table.AddRow(2, "Zaal Verwijderen");
            table.AddRow(3, "Terug");
            table.Write();
            string userselection = Console.ReadLine();
            
            switch (Convert.ToInt32(userselection))
            {
                case 1:
                    AddHall();
                    break;
                case 2:
                    DeleteHall();
                    break;
                case 3:
                    printSchema();
                    break;
            }
        }

        public static void printSchema()
        {
            string userselection;
            var filePath = "filmsforschema.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var MovieList = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData)
                                  ?? new List<FilmsforSchema>();
            int hallAmount = 0;
            foreach (var hallnum in (dynamic)MovieList)
            {
                hallAmount = int.Parse($"{hallnum.HallNumber}");
            }
            var table = new ConsoleTable("ID", "Menu");

            table.AddRow(1, "Zaal overzicht schema");
            table.AddRow(2, "Film tijd info");
            table.AddRow(3, "Bewerk films");
            table.AddRow(4, "Zaal toevoegen");
            table.AddRow("0", "Hoofdmenu");
            table.Write();

            userselection = Console.ReadLine();

            switch (Convert.ToInt32(userselection))
            {
                case 1:
                    HallsSchema();
                    break;
                case 2:
                    Movietime();
                    break;
                case 3:
                    editMovieOnSchema();
                    break;
                case 4:
                    AddHall();
                    break;
                case 0:
                    ConsoleProgram.HomeScreen();
                    break;
            }
            printSchema();
            jsonData = JsonConvert.SerializeObject(MovieList);
            File.WriteAllText(filePath, jsonData);
        }

        public static void HomeScreen()
        {
            //fill the schema with actual playing movies when the user logs in or creates an new account.
            Interface.FillSchema();

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
                    table.AddRow("4", "Alle reserveringen");
                    table.AddRow("5", "Film schema");
                    table.Write();

                    userselection = Console.ReadLine();

                    switch (Convert.ToInt32(userselection))
                    {
                        case 1:
                            NowPlayingMovies();
                            GoToHome();
                            break;
                        case 2:
                            AllUsers();
                            break;
                        case 3:
                            AddReservation();
                            break;
                        case 4:
                            AllReservations();
                            break;
                        case 5:
                            printSchema();
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
                            GoToHome();
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
        
        //Displays the seats array and lets users select seats
        public static Seat[] SeatSelectionScreen(int seatAmount, Hall hall)
        {
            //Unorganized mess
            int pos1 = -1;
            int pos2 = -1;
            //int seatAmount = 2;
    
            //Temp seat array for display purposes
            Seat[][] tseats = hall.getSeats();
            tseats[2][4].setSeatAvailability(false);
            tseats[1][2].setSeatAvailability(false);
            tseats[1][3].setSeatAvailability(false);
            List<Seat> chosenOnes = new List<Seat>();
            bool test = false;

            Console.WriteLine("Kies 1: voor automatische stoel selectie...");
            Console.WriteLine("Kies 2: voor handmatige selectie...");
            if (Console.ReadLine() == 2.ToString())
            {
                test = true;
            }
            
            
            //Systematic Hydromatic Automatic.. well why couldnt it be Automatic Selection
            if (!test)
            {
                while (seatAmount > 0)
                {
                    
                    for (int a = 0; a < tseats[0].Length; a++)
                    {
                        //Console.WriteLine("A" + a);
                        for (int b = 0; b < tseats.Length-2; b++)
                        {
                            if (seatAmount > 0)
                            {
                                //Console.WriteLine("B" + b);
                                if (tseats[a][b].getSeatAvailability() == true)
                                {
                                    chosenOnes.Add(tseats[a][b]);
                                    tseats[a][b].setSeatAvailability(false);
                                    tseats[a][b].SeatIndex = "R: " + (a + 1).ToString() + " S:" + (b + 1).ToString();
                                    seatAmount--;
                                }
                            }
                        }
                        
                    }
                    
                }
            }
            
            //Manual Selection
            if (test)
            {
                //Lets the user select seats untill all are selected
                while (seatAmount > 0)
                {
                    Console.Clear();
                    Console.Write("  ");
                    //Array position to letter
                    for (int a = 0; a < tseats[0].Length; a++)
                    {
                        Console.Write("  ");
                        Console.Write(a + 1);
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
                                case 'D':
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    tseats[i][j].seatAvailability = false;
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
                    else // there is mastercard and ingrid
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
                        pos2 = Int32.Parse(seatChoice2!) - 1; //Interface.ToNumberPosition(seatChoice2!.ToUpper());
                        chosenOnes.Add(tseats[pos1][pos2]);
                        tseats[pos1][pos2].setSeatAvailability(false);
                        tseats[pos1][pos2].SeatIndex = "R: " + (pos1+1).ToString() + " S:" + (pos2+1).ToString();
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            return Interface.ArrayListToArray(chosenOnes);
        }
    }
}
