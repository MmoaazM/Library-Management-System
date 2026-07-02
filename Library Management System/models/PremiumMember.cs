using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public class PremiumMember : Member
    {
        public override int MaxBorrowLimit => 10;
        public override int LoanDays => 30;

        public PremiumMember(int ID, string Name, string Email, DateTime JoinDate) : base(ID, Name, Email, JoinDate) { }
    }
}
