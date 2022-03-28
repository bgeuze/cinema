﻿using System;
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
    internal class MovieJsonHandler
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
            DateTime date1 = new DateTime((int)year, (int)month, (int)day);
            System.Globalization.Calendar cal = dfi.Calendar;

            string WeekNum = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();

            schemaList.Add(new Schema(day.ToString(), month.ToString(), year.ToString(), WeekNum.ToString()));
            jsonData = JsonConvert.SerializeObject(schemaList);
            File.WriteAllText(filePath, jsonData);
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
            }

            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData) ?? new List<Movie>();

            movieList.Add(new Movie(215, "Baruchs Adventure Movie", "16-02-2022", "Adventure movie about the life of Baruch :)"));

            jsonData = JsonConvert.SerializeObject(movieList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }

        public static bool AddReservation(string username, string userId, bool barReservation)
        {
            var filePath = "reservations.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

            //add new reservation to the list
            reservationList.Add(new Reservation(null, username, barReservation, userId, DateTime.Now));
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
                    userReservations.Add(new Reservation(reservation.Id, reservation.Name, reservation.BarReservation, reservation.UserID, reservation.CreatedDateTime));
                }
            }
            return userReservations;
        }
    }
}