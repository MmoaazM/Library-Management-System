using System;
using System.Collections.Generic;
using System.Text;
using Library_Management_System.Interfaces;

namespace Library_Management_System.models
{
    public abstract class Member:ISearchable
    {
        public int ID { get;}
        public string Name { get;}
        public string Email { get;}
        public DateTime JoinDate { get;}
        public List<Book>BorrowedBooks ;

        public abstract int MaxBorrowLimit { get; }
        public abstract int LoanDays{ get; }

        public Member(int ID,string Name,string Email,DateTime JoinDate)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.JoinDate = JoinDate;
            BorrowedBooks = new List<Book>();
        }

        public bool matchesQuery(string query)
        {
            return true;
        }
    }
}
