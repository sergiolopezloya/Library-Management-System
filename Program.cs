using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Variables for Books
            string[] books = new string[5];
            bool[] isBorrowed = new bool[5];
            int borrowedCount = 0;
            const int maxBorrowedBooks = 3;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an action: add, remove, display, search, borrow, checkin, exit");
                string action = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(action))
                {
                    Console.WriteLine("No input provided. Please enter a valid action.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();

                if (action == "add")
                {
                    if (Array.Exists(books, book => string.IsNullOrEmpty(book)))
                    {
                        Console.WriteLine("Enter the title of the book to add:");
                        string newBook = Console.ReadLine()?.Trim();

                        if (!string.IsNullOrEmpty(newBook))
                        {
                            for (int i = 0; i < books.Length; i++)
                            {
                                if (string.IsNullOrEmpty(books[i]))
                                {
                                    books[i] = newBook;
                                    Console.WriteLine("Book added successfully.");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid book title.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The library is full. No more books can be added.");
                    }
                }
                else if (action == "remove")
                {
                    if (Array.Exists(books, book => !string.IsNullOrEmpty(book)))
                    {
                        Console.WriteLine("Enter the title of the book to remove:");
                        string removeBook = Console.ReadLine()?.Trim().ToLower();

                        bool bookFound = false;
                        for (int i = 0; i < books.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(books[i]) && books[i].ToLower() == removeBook)
                            {
                                books[i] = string.Empty;
                                isBorrowed[i] = false;
                                Console.WriteLine("Book removed successfully.");
                                bookFound = true;
                                break;
                            }
                        }

                        if (!bookFound)
                        {
                            Console.WriteLine("Book not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No books to remove.");
                    }
                }
                else if (action == "display")
                {
                    Console.WriteLine("Books in the library:");
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(books[i]))
                        {
                            Console.WriteLine($"{books[i]} {(isBorrowed[i] ? "(Borrowed)" : "(Checked in)")}");
                        }
                    }
                }
                else if (action == "search")
                {
                    Console.WriteLine("Enter the title of the book to search:");
                    string searchBook = Console.ReadLine()?.Trim().ToLower();

                    bool bookFound = false;
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(books[i]) && books[i].ToLower() == searchBook)
                        {
                            Console.WriteLine($"Book '{books[i]}' is available in the library.");
                            bookFound = true;
                            break;
                        }
                    }

                    if (!bookFound)
                    {
                        Console.WriteLine("Book not found in the library.");
                    }
                }
                else if (action == "borrow")
                {
                    if (borrowedCount >= maxBorrowedBooks)
                    {
                        Console.WriteLine("You have reached the maximum number of borrowed books.");
                    }
                    else
                    {
                        Console.WriteLine("Enter the title of the book to borrow:");
                        string borrowBook = Console.ReadLine()?.Trim().ToLower();

                        bool bookFound = false;
                        for (int i = 0; i < books.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(books[i]) && books[i].ToLower() == borrowBook && !isBorrowed[i])
                            {
                                isBorrowed[i] = true;
                                borrowedCount++;
                                Console.WriteLine($"You have borrowed '{books[i]}'.");
                                bookFound = true;
                                break;
                            }
                        }

                        if (!bookFound)
                        {
                            Console.WriteLine("Book not found or already borrowed.");
                        }
                    }
                }
                else if (action == "checkin")
                {
                    Console.WriteLine("Enter the title of the book to check in:");
                    string checkinBook = Console.ReadLine()?.Trim().ToLower();

                    bool bookFound = false;
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(books[i]) && books[i].ToLower() == checkinBook && isBorrowed[i])
                        {
                            isBorrowed[i] = false;
                            borrowedCount--;
                            Console.WriteLine($"You have checked in '{books[i]}'.");
                            bookFound = true;
                            break;
                        }
                    }

                    if (!bookFound)
                    {
                        Console.WriteLine("Book not found or not borrowed.");
                    }
                }
                else if (action == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid action. Please choose add, remove, display, search, borrow, checkin, or exit.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}