using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SorterDLL
{
    public class Sorter
    {
        public static int[] Sort(int[] iSorter)
        {
            Array.Sort(iSorter);
            Array.Reverse(iSorter);
            return iSorter;
        }
    }
}
