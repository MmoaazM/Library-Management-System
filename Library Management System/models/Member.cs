using System;
using System.Collections.Generic;
using System.Reflection;
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

        public List<KeyValuePair<string,string>> GetInfo()
        {
            var members = new List<KeyValuePair<string, string>>();

            foreach (var prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object value = prop.GetValue(this);

                if(prop.Name == nameof(BorrowedBooks) && value is List<Book>Books)
                {
                    string text = Books.Count == 0 ? "none" : string.Join(",",Books.Select(b => b.title));
                    members.Add(new KeyValuePair<string, string>(prop.Name, text));
                    continue;
                }

                members.Add(new KeyValuePair<string,string> (prop.Name, value?.ToString() ?? "null"));
            }

            return members;
        }

        public bool matchesQuery(string query)
        {
            return true;
        }
    }
}
