using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public record BorrowRecord
    {
        public int ID { get; }
        public Book BorrowedBook { get; }
        public Member Borrower { get; }
        public DateTime BorrowDate { get; }
        public DateTime ? ReturnDate { get; set; }

        public BorrowRecord(int ID,Book BorrowedBook, Member Borrower, DateTime BorrowDate)
        {
            this.ID = ID;
            this.BorrowedBook = BorrowedBook;
            this.Borrower = Borrower;
            this.BorrowDate = BorrowDate;
        }


        public bool IsLate()
        {
            return (DateTime.Now - BorrowDate).TotalDays > Borrower.LoanDays;
        }
    }
}
