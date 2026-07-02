using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public abstract class LibraryItem
    {
        protected int ID { get; init; }
        protected string title { get; init; }

        protected DateTime AddedDate { get; init; }

        protected abstract List<KeyValuePair<string,string>> getInfo();

        
    }
}
