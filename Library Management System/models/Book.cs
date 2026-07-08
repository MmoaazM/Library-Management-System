using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Library_Management_System.Interfaces;

namespace Library_Management_System.models
{
    public class Book : LibraryItem , ISearchable
    {
        public string author { get; set; }
        public int year { get; set; }

        public char genre { get; set; }

        public bool isAvailable { get; set; }
        public bool matchesQuery(string query)
        {
            return String.Equals(query,this.title,StringComparison.OrdinalIgnoreCase);
        }

        public override List<KeyValuePair<string,string>>getInfo() //use reflection here
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
