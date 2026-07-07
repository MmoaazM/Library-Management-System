using System;
using System.Collections.Generic;
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


            members.Add(new RegularMember(1, "Moaaz", "Moaaz@gmail.com",new DateTime(2026,9,3)));
            members.Add(new RegularMember(2, "Mohammed", "Mohamed@gmail.com",new DateTime(2019,7,26)));
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


            Member newMember;
            if (Console.Read()=='Y')
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

            if (chosedBook == null) throw new Exception("There is no Book with this ID");
            if (chosenMember == null) throw new Exception("There is no Member with this ID");

            if (!chosedBook.isAvailable) throw new Exception("The Book isn't available now ");

            chosenMember.BorrowedBooks.Add(chosedBook);
            chosedBook.isAvailable = false;

            BorrowRecord newRecord = new BorrowRecord(records.Count+1, chosedBook, chosenMember, DateTime.Now);
            records.Add(newRecord);

            Console.WriteLine("The Member Borrowed his book successfully");
        }

        public void ReturnBook(int bookId)
        {
            Book? chosenBook = books.FirstOrDefault(b => b.ID == bookId);
            if (chosenBook == null) throw new Exception("There is no Book with this ID");
            if (chosenBook.isAvailable) throw new Exception("The Book is Available already");


            BorrowRecord ?theRecord = records.FirstOrDefault(r => r.BorrowedBook.ID == bookId);

            theRecord.ReturnDate = DateTime.Now;
            chosenBook.isAvailable = true;
            
            Member theBorrower = members.FirstOrDefault(member => member.BorrowedBooks.FirstOrDefault(book => book.ID == chosenBook.ID) != null);
            theBorrower.BorrowedBooks.RemoveAll(b => b.ID == bookId);


            Console.WriteLine("The Book Has Been Returned Successfully");
        }

        public void ViewAvailableBooks()
        {
            Header("Viewing Available Books");
            bool thereisAvailable = false;

            foreach(Book book in books)
            {
                if (book.isAvailable)
                {
                    thereisAvailable = true;

                    var info = book.getInfo();
                    Console.WriteLine("\t\t -- Available Books Info");
                    foreach(var pair in info)
                    {
                        Console.WriteLine($"{pair.Key} : {pair.Value}");
                    }
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
                
            Header($"Borrow History for User ID {userId}");

            foreach(var record in records)
            {
                if(record.Borrower.ID==userId)
                {
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
        }

        


    }
}
