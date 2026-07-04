using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public abstract class LibraryItem
    {
        public int ID { get; init; }
        public string title { get; init; }
        
        public DateTime AddedDate { get; init; }
        
        public abstract List<KeyValuePair<string,string>> getInfo();

        
    }
}
