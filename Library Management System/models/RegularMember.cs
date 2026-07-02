using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public class RegularMember : Member
    {
        public override int MaxBorrowLimit => 5;
        public override int LoanDays => 14;

        public RegularMember(int ID, string Name, string Email, DateTime JoinDate) : base(ID, Name, Email, JoinDate) { }

    }
}
