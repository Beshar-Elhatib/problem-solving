using System;
using System.Collections.Generic;
using System.Linq;

namespace Third_day
{

    /*
      Required:
        Write a program that manages a book library, where the user can:
        . 1Add a new book that contains:
        - (unique number) ISBN
        - Title
        - Author
        - Year of publication
        - Number of copies available
        . 2View all books
        . 3Search for a book using:
        - Title or
        - Author's name
        . 4Borrow a book:
        - 1 → Reduces copies by 0 if copies > 
        - If there are no copies → The message "Unavailable" appears
        . 5)Top Borrowed BooksView the most borrowed books (
     */
    class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }
        public int BorrowCount { get; set; }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            Console.Write("Enter Year of Publication: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter Number of Copies: ");
            int copies = int.Parse(Console.ReadLine());

            books.Add(new Book { ISBN = isbn, Title = title, Author = author, Year = year, Copies = copies, BorrowCount = 0 });
            Console.WriteLine("Book added successfully!");
        }

        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"ISBN: {book.ISBN} | Title: {book.Title} | Author: {book.Author} | Year: {book.Year} | Copies: {book.Copies} | Borrowed: {book.BorrowCount}");
            }
        }

        public void SearchBook()
        {
            Console.Write("Enter Title or Author to search: ");
            string query = Console.ReadLine().ToLower();

            var result = books.Where(b => b.Title.ToLower().Contains(query) || b.Author.ToLower().Contains(query)).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No matching books found.");
                return;
            }

            foreach (var book in result)
            {
                Console.WriteLine($"ISBN: {book.ISBN} | Title: {book.Title} | Author: {book.Author} | Year: {book.Year} | Copies: {book.Copies}");
            }
        }

        public void BorrowBook()
        {
            Console.Write("Enter ISBN of the book to borrow: ");
            string isbn = Console.ReadLine();

            var book = books.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (book.Copies > 0)
            {
                book.Copies--;
                book.BorrowCount++;
                Console.WriteLine("Book borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Unavailable.");
            }
        }

        public void TopBorrowedBooks()
        {
            var topBooks = books.OrderByDescending(b => b.BorrowCount).Take(5);

            Console.WriteLine("Top Borrowed Books:");
            foreach (var book in topBooks)
            {
                Console.WriteLine($"{book.Title} | Borrowed: {book.BorrowCount} times");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            while (true)
            {
                Console.WriteLine("\n1. Add Book");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Borrow Book");
                Console.WriteLine("5. Top Borrowed Books");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": library.AddBook(); break;
                    case "2": library.DisplayBooks(); break;
                    case "3": library.SearchBook(); break;
                    case "4": library.BorrowBook(); break;
                    case "5": library.TopBorrowedBooks(); break;
                    case "6": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
    }
}