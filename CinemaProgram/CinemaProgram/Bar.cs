using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    public class Bar
    {

        public int TableNumber;
        public bool Available;
        public int MaxSeatsPerTable = 4;

        public Bar(int tablesAmount)
        {
            this.TableNumber = tablesAmount;
            this.Available = true;
        }

        public int assignTable(int persons)
        {
            if (TableNumber <= 0 && !Available)
            {
                Available = false; return 0;
            }

            int requiredTables = (persons + MaxSeatsPerTable - 1) / MaxSeatsPerTable;
            
            if (TableNumber >= requiredTables)
            {
                TableNumber -= requiredTables;
                return requiredTables;
            }
            return 0;
        }

        public void orderCancelation(int tables)
        {
            this.TableNumber += tables;
            
        }
    }
}