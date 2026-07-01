using System;
using System.Collections.Generic;
using System.Text;
using Library_Management_System.Interfaces;

namespace Library_Management_System.models
{
    public class Book : LibraryItem , ISearchable
    {
        public string author { get; init; }
        public int year { get; init; }

        public char genre { get; init; }

        public bool isAvailable { get; init; }
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
