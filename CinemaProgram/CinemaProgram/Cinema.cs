using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Cinema
    {
        private string cinemaName;

        public Cinema(string name)
        { 
            this.cinemaName = name;
<<<<<<< Updated upstream
=======
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

        public void setName(string name) { this.cinemaName = name; }
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
>>>>>>> Stashed changes
        }
    }
}
