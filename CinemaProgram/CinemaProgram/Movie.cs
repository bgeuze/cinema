﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public bool Adult { get; set; }

        public int duration { get; set; }

        public Movie(int id, string title, string release_date, string overview, bool adult, int duration = 1500)
        {
            Id = id;
            Title = title;
            ReleaseDate = release_date;
            Description = overview;
            Adult = adult;
            this.duration = duration;
        }

        public string getTitle() { return Title; }
        public string getReleaseDate() { return ReleaseDate; }
        public bool getAdult() { return Adult; }
    }
}
