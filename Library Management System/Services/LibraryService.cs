using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Library_Management_System.models;

namespace Library_Management_System.Services
{
    public class LibraryService
    {
        private List<Member> members;
        private List<Book> books;
        private List<BorrowRecord> records;
        private void Header(string title)
        {
            Console.WriteLine("===================================================");
            Console.WriteLine($"\t\t{title}");
            Console.WriteLine("===================================================");
        }
        public void LoadMockData()
        {
            members = new List<Member>();
            books = new List<Book>();
            records = new List<BorrowRecord>();


            members.Add(new PremiumMember(1, "Moaaz", "Moaaz@gmail.com",new DateTime(2026,9,3)));
            members.Add(new PremiumMember(2, "Mohammed", "Mohamed@gmail.com",new DateTime(2019,7,26)));
            members.Add(new RegularMember(3, "ALi", "Ali@gmail.com",new DateTime(2025,1,17)));
            members.Add(new RegularMember(4, "Zyad", "Zyad@gmail.com",new DateTime(2021,5,29)));
            members.Add(new RegularMember(5, "Ibrahim", "Ibrahim@gmail.com",new DateTime(2024,11,9)));

            books.Add(new Book { ID=1,title="Seven Kingdoms",AddedDate=new DateTime(2025,5,15),author="Jean",year=2015,genre='M',isAvailable=true});
            books.Add(new Book { ID = 2, title = "The Invincible", AddedDate = new DateTime(2026, 7, 15), author="Emile",year=2015,genre='F',isAvailable=true});
            books.Add(new Book { ID = 3, title = "Peace", AddedDate = new DateTime(2019, 8, 15), author="Jordan",year=2015,genre='M',isAvailable=true});
            books.Add(new Book { ID = 4, title = "Interstellar", AddedDate = new DateTime(2018, 9, 15), author="Clark",year=2015,genre='M',isAvailable=true});
            books.Add(new Book { ID = 5, title = "The Last Princess", AddedDate = new DateTime(2023, 10, 15), author="Gon switker",year=2015,genre='M',isAvailable=true});
            books.Add(new Book { ID = 6, title = "The Titans", AddedDate = new DateTime(2022, 1, 15), author="Nelson",year=2015,genre='M',isAvailable=true});
            books.Add(new Book { ID = 7, title = "What IF ?", AddedDate = new DateTime(2020, 3, 15), author="Pip armenser",year=2015,genre='M',isAvailable=true});
            books.Add(new Book { ID = 8, title = "World War II", AddedDate = new DateTime(2016, 4, 15), author="Josiph Jonson",year=2015,genre='M',isAvailable=true});

            records.Add(new BorrowRecord(1, new Book { ID = 8, title = "World War II", AddedDate = new DateTime(2016, 4, 15), author = "Josiph Jonson", year = 2015, genre = 'M', isAvailable = true }, new PremiumMember(1, "Moaaz", "Moaaz@gmail.com", new DateTime(2026, 9, 3)), new DateTime(2025, 5, 15))); // mock late report (sorry for put instance with constructor calling)
        }
        public int ShowMainMenu()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("\tWelcome To Library Management System");
            Console.WriteLine("======================================================\n");

            Console.WriteLine("[ 1 ] Register a Member");
            Console.WriteLine("[ 2 ] Search The Catalog");
            Console.WriteLine("[ 3 ] View Available Books");
            Console.WriteLine("[ 4 ] Member Borrowing History");
            Console.WriteLine("[ 5 ] Late Return Report");
            Console.WriteLine("[ 6 ] Add A Book");
            Console.WriteLine("[ 7 ] Borrow A Book");
            Console.WriteLine("[ 8 ] Return A Book");

            Console.Write("Enter Your Choice -> ");

            if (!(int.TryParse(Console.ReadLine(), out int choice)))
            {
                Console.WriteLine("You Entered Invalid Input");
                return 0;
            }

            return choice;

        }


        public void AddBook()
        {
            Header("Adding Book");

            Book newBook = new();

            newBook.ID = books.Count+1;

            Console.Write("Enter Title : ");
            newBook.title = Console.ReadLine();

            Console.Write("Enter Author : ");
            newBook.author = Console.ReadLine();

            Console.Write("Enter Genre : ");
            newBook.genre = Console.ReadLine()=="male"?'M':'F';

            Console.Write("Enter year : ");
            newBook.year = int.Parse(Console.ReadLine());


            newBook.isAvailable = true;
            newBook.AddedDate = DateTime.Now;


            books.Add(newBook);

            Console.WriteLine("The Book Has been added successfully");

        }

        public void RegisterNewMember()
        {
            Header("Registering");

            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Email : ");
            string email = Console.ReadLine();

            Console.Write("Premium ? [ Y ] - [ N ]");
            string memberType = Console.ReadLine();


            Member newMember;
            if (memberType == "Y")
            {
                 newMember = new PremiumMember(members.Count+1, name, email, DateTime.Now);
            }
            else
            {
                 newMember = new RegularMember(members.Count+1, name, email, DateTime.Now);
            }

            if (members.FirstOrDefault(user => user.Email == email) != null)
            {
                Console.WriteLine("[ Failed to ADD ]  The User Already Exists");
                return;
            }
               
            members.Add(newMember);
        }

        public void BorrowBook(int memberId,int bookId)
        {
            Book ?chosedBook = books.FirstOrDefault(b => b.ID == bookId);
            Member? chosenMember = members.FirstOrDefault(m => m.ID == memberId);

            if (chosedBook == null)
            {
                Console.WriteLine("There is no Book with this ID");
                return;
            }
            if (chosenMember == null)
            {
                Console.WriteLine("There is no Member with this ID");
                return;
            }

            if (!chosedBook.isAvailable)
            {
                if (chosenMember.BorrowedBooks.FirstOrDefault(chosedBook) != null)
                { 
                    Console.WriteLine("You Already borrowed this book");
                    return;
                }

                Console.WriteLine("The Book isn't available now");
                return;
            }
            if(chosenMember.MaxBorrowLimit==chosenMember.BorrowedBooks.Count)
            {
                Console.WriteLine("[ failed ]This Member Reached His Max Limit Borrow");
                return;
            }

            chosenMember.BorrowedBooks.Add(chosedBook);
            chosedBook.isAvailable = false;

            BorrowRecord newRecord = new BorrowRecord(records.Count+1, chosedBook, chosenMember, DateTime.Now);
            records.Add(newRecord);

            Console.WriteLine("The Member Borrowed his book successfully");
        }

        public void ReturnBook(int bookId)
        {
            Book? chosenBook = books.FirstOrDefault(b => b.ID == bookId);
            if (chosenBook == null)
            {
                Console.WriteLine("There is no Book with this ID");
                return;
            }
            if (chosenBook.isAvailable)
            {
                Console.WriteLine("The Book is Available already");
                return;
            }

            BorrowRecord? theRecord = records.FirstOrDefault(r => r.BorrowedBook.ID == bookId);

            theRecord.ReturnDate = DateTime.Now;
            chosenBook.isAvailable = true;
            
            Member theBorrower = theRecord.Borrower;
            theBorrower.BorrowedBooks.RemoveAll(b => b.ID == bookId);


            Console.WriteLine("The Book Has Been Returned Successfully");
        }

        public void ViewAvailableBooks()
        {
            Header("Viewing Available Books");
            Console.WriteLine("\t\t -- Available Books Info\n");
            bool thereisAvailable = false;

            foreach(Book book in books)
            {
                if (book.isAvailable)
                {
                    thereisAvailable = true;

                    var info = book.getInfo();
                    
                    foreach(var pair in info)
                    {
                        Console.WriteLine($"{pair.Key} : {pair.Value}");
                    }
                    Console.WriteLine("\n\t---------\n");
                }
            }
            if (!thereisAvailable)
                Console.WriteLine("There aren't available books");
        }

        public void BorrowHistoryForUser()
        {
            int userId;
            Console.Write("Enter the User ID you want : ");
            userId = int.Parse(Console.ReadLine());

            if(userId<0 || userId>members.Count-1)
            {
                Console.WriteLine($"\n[ failed ] There is no user with this id {userId}\n");
                return;
            }
                
            Header($"Borrow History for User ID {userId}");

            bool thereIsRecords = false;
            foreach (var record in records)
            {
                if(record.Borrower.ID==userId)
                {
                    thereIsRecords = true;
                    Console.WriteLine($"Book Title : {record.BorrowedBook.title}");
                    Console.WriteLine($"Borrow date : {record.BorrowDate}");
                    
                    if(!(record.ReturnDate is null))
                    {
                        Console.WriteLine($"Return date : {record.ReturnDate}");
                        if (record.IsLate())
                            Console.WriteLine("This Book's Borrow Period exceeded the legal time  !!");
                        continue;
                    }
                    Console.WriteLine("The Book Hasn't been returned yet");
                }
            }
            if(!thereIsRecords)
            {
                Console.WriteLine("No Borrows For This User");
            }
        }

        public void LateReturnReport()
        {
            Header("Late Return Books Report");
            bool exist = false;
            foreach(var record in records)
            {
                if(record.ReturnDate is null && record.IsLate())
                {
                    exist = true;
                    Console.WriteLine($"Member Name : {record.Borrower.Name}");
                    Console.WriteLine($"Book : {record.BorrowedBook.title}");
                    Console.WriteLine($"Borrow Date : {record.BorrowDate}");
                    Console.WriteLine($"The Return date is late with {(DateTime.Now-record.BorrowDate).TotalDays-record.Borrower.LoanDays} days");
                }
            }
            if(!exist)
            {
                Console.WriteLine("[ Legal ] : all books borrow period are legal");
            }
        }

        public void SearchTheCatalog(string query)
        {
            Header("Search the Catalog");

            bool exist = false;
            foreach(Book book in books)
            {
                if(book.matchesQuery(query))
                {
                    exist = true;
                    Console.WriteLine("Matched Book Info ");
                    var list = book.getInfo();

                    foreach(var pair in list)
                    {
                        Console.WriteLine($"{pair.Key} : {pair.Value}");
                    }
                }
            }
            if(!exist)
            {
                Console.WriteLine("No Books with this title");
            }

            exist = false;

            foreach(Member member in members)
            {
                if(member.matchesQuery(query))
                {
                    exist = true;
                    Console.WriteLine("Matched Member Info ");
                    var list = member.GetInfo();

                    foreach(var pair in list)
                    {
                        Console.WriteLine($"{pair.Key} : {pair.Value}");
                    }
                }
            }
            if (!exist)
            {
                Console.WriteLine("No Members with this title");
            }
        }
    }
}
