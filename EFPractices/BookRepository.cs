using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using AppContext = EFPractices.AppContext;

namespace EFPractices
{
    public class BookRepository
    {


        public static void BookMenu()
        {
            var book = new Book();
            Console.WriteLine("В меню Book Вам доступны следующие действия: ");
            Console.WriteLine("1.выбор книги из БД по его Id");
            Console.WriteLine("2.выбор всех книг БД");
            Console.WriteLine("3.добавить книгу в БД");
            Console.WriteLine("4. удаление книги из БД");
            Console.WriteLine("5.обновление года выпуска книги (по Id)");
            Console.WriteLine(Command.stop + ": прекращение работы");
            string command;
            do
            {
                Console.WriteLine(" Ввидите команду");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        SelectBook();
                        break;
                    case "2":
                        SelectAllBook();
                        break;
                    case "3":
                        AddBook();

                        break;
                    case "4":
                        RemoveBook();
                        break;
                    case "5":
                        UpdateBook();
                        break;

                }
                Console.WriteLine();

            }
            while (command != nameof(Command.stop));
            Console.WriteLine("Работа прекращена");


        }
        public static void SelectBook()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите Id книги");
            var Id = Int32.Parse(Console.ReadLine());
            var book = db.Books.Where(c => c.Id == Id).FirstOrDefault();
            Console.WriteLine(book.Name);
        }
        public static void SelectAllBook()
        {
            var db = new AppContext();
            var allBooks = db.Books.ToList();
            foreach (var book in allBooks)
            {
                Console.WriteLine($"{book.Name} {book.Id}");

            }
        }
        public static void AddBook()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите название книги");
            string name = Console.ReadLine();
            Console.WriteLine("Ввидите дату издания");
            var year =Int32.Parse( Console.ReadLine());

            Book book = new Book { Name = name, Year = year };
            db.Books.Add(book);
            db.SaveChanges();

        }
        public static void RemoveBook()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите Id книги для удаления");
            var Id = Int32.Parse(Console.ReadLine());

            Book book = db.Books.Where(b => b.Id == Id).FirstOrDefault();

            db.Books.Remove(book);
            db.SaveChanges();
        }
        public static void UpdateBook()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите Id книги");
            var Id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ввидте новое имя книги");
            string newName = Console.ReadLine();

            db.Books.Where(b => b.Id == Id).First().Name = newName;
            db.SaveChanges();
        }
        public enum Command
        {
            stop
        }
    }
}




