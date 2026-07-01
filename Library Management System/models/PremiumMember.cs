using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public class PremiumMember : Member
    {
        public int MaxBorrowLimit { get; }
        public int LoanDays { get; }
        public PremiumMember(int ID,string Name,string Email,DateTime JoinDate, int MaxBorrowLimit, int LoanDays) :base(ID, Name, Email, JoinDate)
        {
            this.MaxBorrowLimit = MaxBorrowLimit;
            this.LoanDays = LoanDays;
        }   
    }
}
