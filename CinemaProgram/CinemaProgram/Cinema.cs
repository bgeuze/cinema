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
        private ArrayList halls = new ArrayList();
        public String test;

        public Cinema(string name, ArrayList halls)
        {
            this.cinemaName = name;
            this.halls = halls;

            test = String.Join(",", halls.ToArray());
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
        public ArrayList getHalls()
        { return halls; }

        internal Hall getHall(int hallnumber)
        {
            foreach (Hall hall in halls)
            {
                if (hall.getHallNumber() == hallnumber)
                {
                    return hall;
                }
            }
            return null;
            // return (Hall)halls[hallnumber];
        }

        internal void addHall(Hall hall)
        {
            Boolean inList = false;
            foreach (Hall obj in halls)
            {
                if (obj.getHallNumber() == hall.getHallNumber())
                {
                    inList = true;
                    Console.WriteLine("MESSAGE; Hall already in Cinema: " + getName());

                }
                else
                {
                    halls.Add(hall);

                    test = String.Join(",", halls.ToArray());
                }
            }
        }
    }
}