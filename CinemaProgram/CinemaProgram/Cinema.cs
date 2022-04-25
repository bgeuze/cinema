using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    public class Cinema
    {
        public string cinemaName;
        public Bar bars = null;
        public ArrayList Halls = new ArrayList();

        public Cinema(string name, ArrayList halls)
        {
            cinemaName = name;
            Halls = halls;
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
        { return Halls; }

        public Hall getHall(int hallnumber)
        {
            foreach (Hall hall in Halls)
            {
                if (hall.getHallNumber() == hallnumber)
                {
                    return hall;
                }
            }
            return null;
            // return (Hall)halls[hallnumber];
        }

        public void addHall(Hall hall)
        {
            Boolean inList = false;
            foreach (Hall obj in Halls)
            {
                if (obj.getHallNumber() == hall.getHallNumber())
                {
                    inList = true;
                    Console.WriteLine("MESSAGE; Hall already in Cinema: " + getName());

                }
                else
                {
                    Halls.Add(hall);
                }
            }
        }
    }
}