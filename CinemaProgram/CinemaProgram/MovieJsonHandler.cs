using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CinemaProgram
{
    public class MovieJsonHandler
    {
        public static bool Schema()
        {
            var filePath = "schema.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var schemaList = JsonConvert.DeserializeObject<List<Schema>>(jsonData)
                                  ?? new List<Schema>();
            DayOfWeek day = (DayOfWeek)DateTime.Today.Day;
            DayOfWeek month = (DayOfWeek)DateTime.Today.Month;
            DayOfWeek year = (DayOfWeek)DateTime.Today.Year;


            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            DateTime date = new DateTime((int)year, (int)month, (int)day);
            System.Globalization.Calendar cal = dfi.Calendar;
            string WeekNum = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();

            int Jday = DateTime.Now.Day;
            int Jmonth = DateTime.Today.Month;
            DayOfWeek Jyear = (DayOfWeek)DateTime.Today.Year;

            schemaList.Add(new Schema(Jday.ToString(), Jmonth.ToString(), Jyear.ToString(), WeekNum.ToString()));
            jsonData = JsonConvert.SerializeObject(schemaList);
            File.WriteAllText(filePath, jsonData);

            printSchema();
            
            return true;
        }
        public static void HallsSchema() {

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

            for (int i = 1; i < hallAmount+1; i++)
            {
                Console.WriteLine($"Alle films in zaal {i}.\n");
                var table = new ConsoleTable("Time", "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag");
                int time = 10;
                foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == i.ToString())
                    {
                        string f = $"{film.MovieTitle}";
                        string starttime = film.StartTime;
                        table.AddRow(starttime, f, f, f, f, f, f, f);
                        time += 2;
                    }
                foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == i.ToString())
                    {
                        string f = $"{film.MovieTitle}";
                        string starttime = film.StartTime;
                        
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
            foreach (var film in (dynamic)MovieList)
            {
                table.AddRow(i, film.MovieTitle);
                i++;
            }
            table.Write();
            Console.WriteLine("\nTyp het nummer van de film waar u informatie van wilt.");
            string movieselection = Console.ReadLine();
            Console.WriteLine(MovieList[int.Parse(movieselection)].MovieTitle);
            string text = MovieList[int.Parse(movieselection)].StartTime;
            string uren = text.Substring(0, text.LastIndexOf(':'));
            string minuten = text.Substring(text.LastIndexOf(':') + 1);
            int hours = int.Parse(uren) + 7;
            string tijd = hours + ":" + minuten;
            Console.WriteLine($"De film draait om {MovieList[int.Parse(movieselection)].StartTime} en om {tijd}");
            Console.WriteLine($"De film draait in zaal {MovieList[int.Parse(movieselection)].HallNumber}\n");

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
                hallAmount = int.Parse($"{hallnum.HallNumber}");
            }
            for (int i = 1; i < hallAmount + 1; i++)
            {
                table.AddRow(i, $"Edit films uit zaal {i}");

            }
            table.Write();

            userselection = Console.ReadLine();

            int count = 1;
            foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == userselection)
                {
                    Console.WriteLine(count + ": " + $"{film.MovieTitle}");
                    count++;
                }

            Console.WriteLine("Enter the initial of the film you want to change.");
            string movieselection = Console.ReadLine();
            count = 1;
            foreach (var film in (dynamic)MovieList) if ($"{film.HallNumber}" == userselection)
                {
                    if (count.ToString() == movieselection)
                    {
                        Console.WriteLine($"Are you sure you want to change: {$"{film.MovieTitle}"}.");
                    }
                    count++;
                }
            Console.WriteLine("\nEnter Yes or No.");
            string YesOrNo = Console.ReadLine();
            if (YesOrNo == "yes" || YesOrNo == "Yes") {
                Console.WriteLine("\nEnter the name of the new Film.");
            } else if (YesOrNo == "no" || YesOrNo == "No") {
                printSchema();
            }

            string newMovie = Console.ReadLine();
            Console.WriteLine("\nHoelaat draait de film voor het eerst op de dag?");
            string newTime = Console.ReadLine();

                count = 1;
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
                hallAmount = int.Parse($"{hallnum.HallNumber}");
            }
            string tijduren = "10";
            string tijdminuten = "00";
            for(int i = 0; i < 3; i++)
            {
                MovieList.Add(new FilmsforSchema((hallAmount+1).ToString(), "Plaatshouder tekst", tijduren+":"+tijdminuten));
                tijduren = (int.Parse(tijduren) + 2).ToString();
            }

            Console.WriteLine($"U heeft zaal {hallAmount+1} toegevoegd.");

            jsonData = JsonConvert.SerializeObject(MovieList);
            File.WriteAllText(filePath, jsonData);
            }


            public static void printSchema(){
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
            table.AddRow(3, "Edit films");
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

        public static bool NowPlayingMovies()
        {
            var filePath = "movies.json";
            //load nowplaying movies from themoviedb endpoint
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://api.themoviedb.org/3/movie/now_playing?api_key=2994dabe7980fbf78dcb92703ce4057a&language=nl-NL&page=1&region=NL");

                var parsedJson = JObject.Parse(json);
                var resultsJson = parsedJson["results"].ToString();
                var allMovies = JsonConvert.DeserializeObject(resultsJson);

                resultsJson = JsonConvert.SerializeObject(allMovies);
                File.WriteAllText(filePath, resultsJson);
            }

            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData) ?? new List<Movie>();

            movieList.Add(new Movie(215, "Baruchs Adventure Movie", "16-02-2022", "Adventure movie about the life of Baruch :)", true));

            jsonData = JsonConvert.SerializeObject(movieList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }

        public static bool AddReservation(string username, string userId, bool barReservation, Seat[] seatlist)
        {
            var filePath = "reservations.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

            //add new reservation to the list
            reservationList.Add(new Reservation(null, username, barReservation, userId, DateTime.Now, seatlist));
            jsonData = JsonConvert.SerializeObject(reservationList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }

        public static List<Reservation> UserReservations(string userId)
        {
            var filePath = "reservations.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

            var userReservations = new List<Reservation>();
            foreach (var reservation in reservationList.ToList())
            {
                if (userId == Convert.ToString(reservation.UserID))
                {
                    userReservations.Add(new Reservation(reservation.Id, reservation.Name, reservation.BarReservation, reservation.UserID, reservation.CreatedDateTime, reservation.SeatList));
                }
            }
            return userReservations;
        }

        public static bool RemoveReservation(string Id)
        {
            var filePath = "reservations.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

            //load json file with all reservations
            using (StreamReader r = new StreamReader("reservations.json"))
            {
                string json = r.ReadToEnd();
                dynamic reservations = JsonConvert.DeserializeObject(json);

                //loop over all reservations objects and check if stored data matches the given param, and delete the reservation
                foreach (var reservation in reservationList)
                {
                    if (Id == Convert.ToString(reservation.Id))
                    {
                        reservationList.Remove(reservation);
                        jsonData = JsonConvert.SerializeObject(reservationList);
                        File.WriteAllText(filePath, jsonData);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
