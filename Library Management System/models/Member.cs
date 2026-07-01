using System;
using System.Collections.Generic;
using System.Text;
using Library_Management_System.Interfaces;

namespace Library_Management_System.models
{
    public class Member:ISearchable
    {
        protected int ID { get;}
        protected string Name { get;}
        protected string Email { get;}
        protected DateTime JoinDate { get;}
        protected Book[] BorrowedBooks ; 

        public Member(int ID,string Name,string Email,DateTime JoinDate)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.JoinDate = JoinDate;
            BorrowedBooks = Array.Empty<Book>();
        }

        public bool matchesQuery(string query)
        {
            return true;
        }
    }
}
