using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    public class Table
    {
        public int tableNumber;
        public int starttime;
        public string date;
        public bool Available;
        //public int MaxSeatsPerTable = 4;

        public void setAvailable(bool value)
        {
            Available = value;
        }

        public void setStarttime(int time)
        {
            starttime = time;
        }
    }
    public class Bar
    {
        public Table[] tables = new Table[40];
        //public int TableNumber;
        public bool Available;
        public int MaxSeatsPerTable = 4;

        public Bar(int tablesAmount)
        {
            //this.TableNumber = tablesAmount;
            this.Available = true;
        }

        public int assignTable(int persons, int startTime, string date)
        {
            int tablesAvailable = 0;
            foreach (Table table in tables)
            {
                if (table.Available)
                {
                    tablesAvailable++;
                }
            }

            if (tablesAvailable <= 0 || !Available)
            {
                Available = false; return 0;
            }
            int requiredTables = (persons + MaxSeatsPerTable - 1) / MaxSeatsPerTable;
            int countDown = requiredTables;
            
                for(int i =0;i < tables.Length; i++)
                {
                    while(countDown != 0)
                    {
                        if (tables[i].Available)
                        {
                            tables[i].starttime = startTime;
                            tables[i].Available = false;
                            tables[i].tableNumber = i + 1;
                            countDown--;
                        }
                    }
                }

                return requiredTables;
            
            /*if (TableNumber <= 0 && !Available)
            {
                Available = false; return 0;
            }
            
            
            
            if (TableNumber >= requiredTables)
            {
                TableNumber -= requiredTables;
                return requiredTables;
            } */
            return 0;
        }

        public void orderCancelation(int tableAmount)
        {
            int countDown = tableAmount;
            
            for(int i =0;i < tables.Length; i++)
            {
                while(countDown != 0)
                {
                    if (!tables[i].Available)
                    {
                        tables[i].starttime = 0;
                        tables[i].Available = true;
                        countDown--;
                    }
                }
            }
            //this.TableNumber += tables;
            
        }
    }
}