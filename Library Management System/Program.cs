using System;
using Library_Management_System.Services;

class Program
{
    static void Main(string[]args)
    {
        LibraryService service = new();
        service.LoadMockData();

        int choice;

        do
        {
            choice = service.ShowMainMenu();
            switch (choice)
            {
                case 1:
                    service.RegisterNewMember();
                    break;
                case 2:
                    Console.Write("Enter The Query for Search : ");
                    service.SearchTheCatalog(Console.ReadLine());
                    break;
                case 3:
                    service.ViewAvailableBooks();
                    break;
                case 4:
                    service.BorrowHistoryForUser();
                    break;
                case 5:
                    service.LateReturnReport();
                    break;
                case 6:
                    service.AddBook();
                    break;
                case 7:
                    Console.Write("Enter The Borrower ID : ");
                    int userId = int.Parse(Console.ReadLine());

                    Console.Write("Enter The Book ID : ");
                    int bookId = int.Parse(Console.ReadLine());

                    service.BorrowBook(userId,bookId);
                    break;
                case 8:
                    Console.Write("Enter the Book Id To return it : ");
                    int BookId = int.Parse(Console.ReadLine());

                    service.ReturnBook(BookId);
                    break;

                default:
                    choice = 1; // any valid number to loop again
                    break;

            }
        } while (choice > 0 && choice < 9);
    }
}
