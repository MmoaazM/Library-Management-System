using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.models
{
    public record BorrowRecord
    {
        int ID { get; }
        Book BorrowedBook { get; }
        Member Borrower { get; }
        DateTime BorrowDate { get; }
        DateTime ReturnDate { get; init; }

        public BorrowRecord(int ID,Book BorrowedBook, Member Borrower, DateTime BorrowDate)
        {
            this.ID = ID;
            this.BorrowedBook = BorrowedBook;
            this.Borrower = Borrower;
            this.BorrowDate = BorrowDate;
        }


        public bool IsLate()
        {
            return (DateTime.Now - BorrowDate).TotalDays > 14;
        }
    }
}
