using System;
using System.Collections.Generic;
using System.Text;
using Library_Management_System.Interfaces;

namespace Library_Management_System.models
{
    internal class Book : LibraryItem , ISearchable
    {
        public string author { get;}
        public int year { get;}

        public char genre { get;}

        public bool isAvailable { get;}
        public bool matchesQuery(string query)
        {
            return true;
        }

        protected override List<KeyValuePair<string,string>>getInfo()
        {
            return null;
        }

        
    }
}
