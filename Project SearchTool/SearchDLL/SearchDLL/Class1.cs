using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDLL
{
    public class Search
    {
        public string[] Names(string query)
        {
            
            string[] names = { "Oliver", "Jake", "Noah", "James", "Jack", "Connor", "Liam", "John", "Harry" };      
            string[] test = Array.FindAll(names, name => name.Contains(query));
 
            return test;
        }
        
    }
}
