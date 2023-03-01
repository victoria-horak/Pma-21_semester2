using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{

    public class Library : IEnumerable<Book>
    {
        private List<Book> books = new List<Book>();
        private string author;

        public Library(string author)
        {
            this.author = author;
        }

        public void addBook(Book book)
        {
            books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this, author);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private Library library;
            private int currentIndex = -1;
            private List<Book> filteredBooks = new List<Book>();
            private string author;

            public LibraryIterator(Library library, string author)
            {
                this.library = library;
                this.author = author;
            }

            public bool MoveNext()
            {

                if (filteredBooks.Count > 0)
                {
                    currentIndex++;
                    return currentIndex < filteredBooks.Count;
                }

                foreach (Book book in library.books)
                {
                    if (book.author == author)
                    {
                        filteredBooks.Add(book);
                    }
                }

                if (filteredBooks.Count > 0)
                {
                    currentIndex = 0;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public Book Current
            {
                get { return filteredBooks[currentIndex]; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
            }
        }
    }

}
