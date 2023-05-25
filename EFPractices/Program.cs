using EFPractices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AppContext = EFPractices.AppContext;

public class Program
{

    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var user1 = new User() { Name = "Arthur", Email = "Admin@gmail.com" };
            var user2 = new User() { Name = "Klim", Email = "User@gmail.com" };
            var user3 = new User() { Name = "Roman", Email = "Roman@gmail.com" };

            var book1 = new Book() { Name = "Война и мир", Year = 1867, Author = "Л.Н Толстой", Gener = "Роман" };
            var book2 = new Book() { Name = "Зеленая Лампа", Year = 1930, Author = "А.Грин", Gener = "Рассказ" };
            var book3 = new Book() { Name = "Идиот", Year = 1868, Author = "Ф.М Достоевский", Gener = "Роман" };
            var book4 = new Book() { Name = "Гарри Поттер", Year = 1997, Author = "Джоан Роулинг", Gener = "Фэнтези" };
            var book5 = new Book() { Name = "Норвежский лес", Year = 2010, Author = "Харуки Мураками", Gener = "Роман" };
            var book6 = new Book() { Name = "Нормальные люди", Year = 2020, Author = " Салли Руни", Gener = "Роман" };

            user1.Books.AddRange(new[] { book3, book4 });
            user2.Books.AddRange(new[] { book5, book1 });
            user3.Books.AddRange(new[] { book2, book6 });

            book4.Users.AddRange(new[] { user1, user2 });

            db.Users.AddRange(user1, user2, user3);

            db.Books.AddRange(book1, book2, book3, book4, book5, book6);

            db.SaveChanges();


        }
        Console.WriteLine("Добро пожаловать!");
        Console.WriteLine("Для работы с меню User нажмите 1 ");
        Console.WriteLine("Для работы с меню Book нажмите 2 ");
        var commands = Console.ReadLine();

        switch (commands)
        {
            case "1":
                UserRepository.UserMenu();
                break;

            case "2":
                BookRepository.BookMenu();
                break;
        }

    }


}
