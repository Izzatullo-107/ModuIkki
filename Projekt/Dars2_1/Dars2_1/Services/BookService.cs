using Dars2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_1.Services;
public class BookService
{
    public List<Book> Books = new List<Book>();

    public Guid AddBook(Book book)
    {
        book.BookId = Guid.NewGuid();
        book.Created = DateTime.UtcNow;
        Books.Add(book);
        return book.BookId;
    }

    public Guid DeleteBook(Guid bookId)
    {
        Book book = null;

        foreach (var b in Books)
        {
            if (b.BookId == bookId)
            {
                book = b;
                break;
            }
        }

        if (book != null)
        {
            Books.Remove(book);
            return bookId;
        }
        return Guid.Empty;
    }

    public List<Book> GetAllBooks()
    {
        return Books;
    }

    public void UpdateBook(Book updatedBook)
    {

        Book existingBook = null;

        foreach (var b in Books)
        {
            if (b.BookId == updatedBook.BookId)
            {
                existingBook = b;
                break;
            }
        }


        if (existingBook != null)
        {
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Price = updatedBook.Price;
            existingBook.Description = updatedBook.Description;
            existingBook.Genre = updatedBook.Genre;
            existingBook.PageCount = updatedBook.PageCount;
        }
    }

    public Book GetById(Guid bookId)
    {
        Book book = null;

        foreach (var b in Books)
        {
            if (b.BookId == bookId)
            {
                book = b;
                break;
            }
        }

        return book;
    }
}
