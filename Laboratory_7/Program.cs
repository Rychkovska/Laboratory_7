using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_7
{
    internal class Program
    {
        static List<Book> books;
        static void PrintBooks ()
        {
            foreach (Book book in books) 
            { 
                Console.WriteLine (book.Info().Replace('i', 'i'));
            }
            Console.WriteLine ();
        }
        static void Main(string[] args)
        {
            books = new List<Book> ();
            FileStream fs = new FileStream("Бінарні_дані.books", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            try
            {
                Book book;
                Console.WriteLine("Читаємо дані з файлу... \n");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    book = new Book();
                    for (int i=1; i<=10; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                book.Title = reader.ReadString(); break;
                            case 2:
                                book.Author = reader.ReadString(); break;
                            case 3:
                                book.NumPages = reader.ReadInt32(); break;
                            case 4:
                                book.WordCount = reader.ReadInt32(); break;
                            case 5:
                                book.Publisher = reader.ReadString(); break;
                            case 6:
                                book.YearPublished = reader.ReadInt32(); break;
                            case 7:
                                book.Language = reader.ReadString(); break;
                            case 8:
                                book.Genre = reader.ReadString(); break;
                            case 9:
                                book.Onthepage = reader.ReadInt32(); break;
                            case 10:
                                book.SizeofBook = reader.ReadBoolean(); break;
                        }
                    }
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally { reader.Close(); }
            Console.WriteLine("Несортований перелік книг: {0}", books.Count);
            PrintBooks();
            books.Sort();
            Console.WriteLine("Сортований перелік книг: {0}", books.Count);
            PrintBooks();
            Console.WriteLine("Додаємо новий запис: Чума");
            Book bookPlague = new Book("Чума", "Альбер Камю", 550, 250000, "French books", 1947,
                "Французька", "Соціальний роман", 250, false);
            books.Add(bookPlague);
            books.Sort();
            Console.WriteLine("Перелік книг: {0}", books.Count);
            PrintBooks();
            Console.WriteLine("Видаляємо останнє значення");
            books.RemoveAt(books.Count - 1);
            Console.WriteLine("Перелік книг: {0}", books.Count);
            PrintBooks();
            Console.ReadKey();
        }

    }
}
