using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public abstract class LibraryItem
    {
        public int ID { get; set; }
        public string title { get; set; }
        
        public DateTime AddedDate { get; set; }
        
        public abstract List<KeyValuePair<string,string>> getInfo();

        
    }
}
