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
        private void Header(string title)
        {
            Console.WriteLine("===================================================");
            Console.WriteLine($"\t\t{title}");
            Console.WriteLine("===================================================");
        }


        public void LoadMockData()
        {
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


    }
}
