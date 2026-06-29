using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.Interfaces
{
    public interface ISearchable
    {
        bool matchesQuery(string query);
    }
}
