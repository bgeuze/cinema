using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Cinema
    {
        private string cinemaName;
        private Bar bars = null;

        public Cinema(string name)
        { 
            this.cinemaName = name;
        }

        internal void addBar(Bar bar)
        {
            bars = bar;
        }

        internal Bar getBar()
        {
            return bars;
        }

        internal string getName()
        {
            return cinemaName;
        }
    }
}
