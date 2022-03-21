using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CinemaProgram
{
    public class Schema
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string WeekNumber { get; set; }

        public Schema(string day, string month, string year, string weeknumber)
        {
            Day = day;
            Month = month;
            Year= year;
            WeekNumber = weeknumber;
        }
    }
}
