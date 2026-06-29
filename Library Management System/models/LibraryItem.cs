using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public abstract class LibraryItem
    {
        protected int ID { get; }
        protected string title { get;}

        protected DateTime addedDate { get;}

        protected abstract List<KeyValuePair<string,string>> getInfo();

        
    }
}
