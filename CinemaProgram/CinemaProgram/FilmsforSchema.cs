using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CinemaProgram
{
    public class FilmsforSchema
    {
        public string HallNumber { get; set; }
        public string MovieTitle { get; set; }
        public string StartTime { get; set; }


        public FilmsforSchema(string hallnumber, string title, string startTime)
        {
            HallNumber = hallnumber;
            MovieTitle = title;
            StartTime = startTime;

         }
    }
}
