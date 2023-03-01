using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input full name author for filtering: ");
            string author = Console.ReadLine();
            Library library = new Library(author);

            library.addBook(new Book { title = "Kateruna", author = "Taras Shevchenko" });
            library.addBook(new Book { title = "Сity", author = "Hryhoriy Skovoroda" });
            library.addBook(new Book { title = "Kobzar", author = "Taras Shevchenko" });
            library.addBook(new Book { title = "Zeus", author = "Michael Board" });
            foreach (Book book in library)
            {
                Console.WriteLine(book.title + " - " + book.author);
            }
        }

    }
}
