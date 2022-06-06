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
        public static bool FillSchema()
        {
            var filePath = "movies.json";
            var filePath2 = "filmsforschema.json";

            //read existing json data
            var jsonData = File.ReadAllText(filePath);

            //de-serialize to object or create new list
            var moviesSchema = JsonConvert.DeserializeObject<List<FilmsforSchema>>(jsonData).Take(9) ?? new List<FilmsforSchema>();
            int k = 1;
            int tijduur1 = 10;
            int tijduur2 = 10;
            int tijduur3 = 10;

            //loop over the objects to add the hallnumber and playing time
            foreach (var movie in (dynamic)moviesSchema.Take(9))
            {
                if(k % 3 == 0)
                {
                    movie.HallNumber = "3";
                    movie.StartTime = $"{tijduur1}:00";
                    movie.hallObject = new Hall(3, 3);
                    tijduur1 += 2;
                }
                else if(k % 3 == 1)
                {
                    movie.HallNumber = "2";
                    movie.StartTime = $"{tijduur2}:00";
                    
                    movie.hallObject = new Hall(2, 2);
                    tijduur2 += 2;
                }
                else
                {
                    movie.HallNumber = "1";
                    movie.StartTime = $"{tijduur3}:00";
                    
                    movie.hallObject = new Hall(1, 1);
                    tijduur3 += 2;
                }
                k += 1;
            }

            jsonData = JsonConvert.SerializeObject(moviesSchema);
            File.WriteAllText(filePath2, jsonData);

            return true;
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

                //var moviesSchema = JsonConvert.DeserializeObject<List<FilmsforSchema>>(resultsJson) ?? new List<FilmsforSchema>();
            }

            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData).Take(9) ?? new List<Movie>();

            jsonData = JsonConvert.SerializeObject(movieList);
            File.WriteAllText(filePath, jsonData);

        

            return true;
        }

        public static bool AddReservation(string username, string userId, bool barReservation, Seat[] seatlist, string FilmTitle, double cost)
        {
            var filePath = "reservations.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

            //add new reservation to the list
            reservationList.Add(new Reservation(null, username, barReservation, userId, DateTime.Now, seatlist, FilmTitle, cost));
            jsonData = JsonConvert.SerializeObject(reservationList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }

        public static List<Reservation> AllReservations()
        {
            var filePath = "reservations.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

            //var userReservations = new List<Reservation>();
            //foreach (var reservation in reservationList.ToList())
            //{
            //    userReservations.Add(new Reservation(reservation.Id, reservation.Name, reservation.BarReservation, reservation.UserID, reservation.CreatedDateTime, reservation.SeatList));
            //}

            return reservationList;
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
                    userReservations.Add(new Reservation(reservation.Id, reservation.Name, reservation.BarReservation, reservation.UserID, reservation.CreatedDateTime, reservation.SeatList, reservation.FilmTitle, reservation.reservationCost));
                }
            }
            return userReservations;
        }

        public static bool RemoveReservation(string Id, string reservationName)
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
                        if (reservation.Name == reservationName)
                        {
                            reservationList.Remove(reservation);
                            jsonData = JsonConvert.SerializeObject(reservationList);
                            File.WriteAllText(filePath, jsonData);
                            ConsoleProgram.GoToHome();
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
