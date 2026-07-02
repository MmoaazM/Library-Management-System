using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
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

        protected override List<KeyValuePair<string,string>>getInfo() //use reflection here
        {
            var members = new List<KeyValuePair<string, string>>();
            
            foreach(var prop in this.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
                object value = prop.GetValue(this);
                members.Add(new KeyValuePair<string, string>(prop.Name, value?.ToString() ?? "null"));
            }
            return members;
        }

        
    }
}
