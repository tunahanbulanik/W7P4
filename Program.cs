using System;
using System.Collections.Generic;
using System.Linq;

class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
}

class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Yazarları tanımlıyoruz
        List<Author> authors = new List<Author>
        {
            new Author { AuthorId = 1, Name = "Orhan Pamuk" },
            new Author { AuthorId = 2, Name = "Elif Şafak" },
            new Author { AuthorId = 3, Name = "Ahmet Ümit" }
        };

        // Kitapları tanımlıyoruz
        List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Kar", AuthorId = 1 },
            new Book { BookId = 2, Title = "İstanbul", AuthorId = 1 },
            new Book { BookId = 3, Title = "10 Minutes 38 Seconds in This Strange World", AuthorId = 2 },
            new Book { BookId = 4, Title = "Beyoğlu Rapsodisi", AuthorId = 3 }
        };

        // LINQ ile join işlemi yaparak kitapları yazarlarla birleştiriyoruz
        var bookAuthorList = from book in books
                             join author in authors
                             on book.AuthorId equals author.AuthorId
                             select new
                             {
                                 BookTitle = book.Title,
                                 AuthorName = author.Name
                             };

        // Sonuçları ekrana yazdırıyoruz
        Console.WriteLine("Kitaplar ve Yazarları:");
        foreach (var item in bookAuthorList)
        {
            Console.WriteLine($"Kitap: {item.BookTitle}, Yazar: {item.AuthorName}");
        }
    }
}
