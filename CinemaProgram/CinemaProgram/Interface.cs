﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace CinemaProgram
{
    public class Interface
    {
        private ArrayList cinemas = new ArrayList();

        public static bool Login(string username, string password)
        {
            return UserJsonHandler.FindUser(username, password);
        }

        public static bool Register(string username, string password, DateTime age)
        {
            return UserJsonHandler.SaveUser(username, password, age);
        }

        public static string GetUserId(string username)
        {
            return UserJsonHandler.GetUserId(username);
        }

        public static string GetUserRole(string username) {
            return UserJsonHandler.GetUserRole(username);
        }
        
        public static DateTime GetUserLeeftijd(string username)
        {
            return UserJsonHandler.GetUserLeeftijd(username);
        }

        public static bool FillSchema()
        {
            return MovieJsonHandler.FillSchema();
        }

        public static bool NowPlayingMovies()
        {
            return MovieJsonHandler.NowPlayingMovies();
        }

        public static bool AddReservation(string username, string userId, bool barReservation, Seat[] seatlist, string FilmTitle, double cost, string playDate, string playTime)
        {
            
            return MovieJsonHandler.AddReservation(username, userId, barReservation, seatlist, FilmTitle, cost, playDate, playTime);
        }

        public static bool RemoveReservation(string Id, string reservationName)
        {
            return MovieJsonHandler.RemoveReservation(Id, reservationName);
        }

        public static List<Reservation> UserReservations(string userId)
        {
            return MovieJsonHandler.UserReservations(userId);
        }

        public static List<Reservation> AllReservations()
        {
            return MovieJsonHandler.AllReservations();
        }

        public Cinema getCinema(string v)
        {
            //return JsonHandler.getMovie(v);
            return null;
        }

        //Creates a cinema and checks if there is no duplicate
        public void newCinema(string name, Hall[] halls)
        {
            //TODO: Add Halls[] instead of the arraylist find any problems
            CinemaJsonHandler.NewCinema(name, halls);
        }

        //Converts an arraylist to an array so it can be saved in/to the JSON
        public static Seat[] ArrayListToArray(List<Seat> aL)
        {
            Seat[] seatArray = aL.ToArray();
            return seatArray;
        }

        //Translates the given letter to the correct array number
        public static int ToNumberPosition(string seatChoice2)
        {
            return seatChoice2 switch
            {
                "A" => 0,
                "B" => 1,
                "C" => 2,
                "D" => 3,
                "E" => 4,
                "F" => 5,
                "G" => 6,
                _ => -1
            };
        }
        
        //Calculate SelectedSeatPricing
        public static double SeatPriceCalculation(Seat[] selectedSeats)
        {
            double cost = 0.0;
            foreach (Seat seat in selectedSeats)
            {
                cost += seat.getPrice();
            }
            return cost;
        }
    }
}
