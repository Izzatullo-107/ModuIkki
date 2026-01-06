namespace Dars2_1
{
    internal class Program
    {
        static List<Book> Books = new List<Book>();
        static void Main(string[] args)
        {
            #region class book
            DataSeed();

            var books = GetExpensiveBooksThenMinPrice(5);



            foreach (var book in MaxPageCountTow())
            {
                Console.WriteLine($"{book.Title} - {book.Price}");
            }
            //var book = GetMaxPricedBook();
            //Console.WriteLine(book.Price);
            #endregion

        }

        #region Class Book
        static Book MaxPageCount()
        {
            Book book = Books[0];
            foreach (var b in Books)
            {
                if (book.PageCount < b.PageCount)
                {
                    book = b;
                }
            }
            return book;
        }

        static List<Book> MaxPageCountTow() 
        {
            List<Book> result = new List<Book>();
            Book first = Books[0];
            Book second = Books[0];
            foreach (var b in Books)
            {
                if (first.PageCount < b.PageCount)
                {
                    second = first;
                    first = b;
                }
                else if (second.PageCount < b.PageCount && first != b)
                {
                    second = b;
                }
            }
            result.Add(first);
            result.Add(second);
            return result;

        }

        static List<Book> GetExpensiveBooksThenMinPrice(decimal minPrice)
        {
            var expensiveBooks = new List<Book>();

            foreach (var book in Books)
            {
                if (book.Price > minPrice)
                {
                    expensiveBooks.Add(book);
                }
            }

            return expensiveBooks;
        }

        static Book GetMaxPricedBook()
        {
            Book book = Books[0];

            foreach (var b in Books)
            {
                if (book.Price < b.Price)
                {
                    book = b;
                }
            }

            return book;
        }


        static void DataSeed()
        {
            Books.Add(new Book()
            {
                BookId = Guid.NewGuid(),
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Price = 10.99m,
                Description = "A novel set in the Jazz Age that tells the story of Jay Gatsby's unrequited love for Daisy Buchanan.",
                Created = DateTime.Now,
                Genre = "Classic",
                PageCount = 180
            });

            Books.Add(new Book()
            {
                BookId = Guid.NewGuid(),
                Title = "Sariq Devni Minib",
                Author = "Xudoyberdi To'xtaboyev",
                Price = 5.99m,
                Description = "Legenda",
                Created = DateTime.Now,
                Genre = "Fantasy",
                PageCount = 270
            });

            Books.Add(new Book()
            {
                BookId = Guid.NewGuid(),
                Title = "Harry Poter",
                Author = "Opa",
                Price = 15.99m,
                Description = "Legenda 2",
                Created = DateTime.Now,
                Genre = "Fantasy",
                PageCount = 870
            });
        }
    }
    #endregion


}
