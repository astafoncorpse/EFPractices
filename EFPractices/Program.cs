using EFPractices;
using System.Runtime.CompilerServices;
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

        using (var db = new AppContext())
        {
            //Получать список книг определенного жанра и вышедших между определенными годами
            var books = db.Books.Where(b => b.Gener == "Роман").Where(y=> y.Year == 1850 - 2020).ToList();
            //Получать количество книг определенного автора в библиотеке
            var countbook = db.Books.Where(a => a.Author == "Джоан Роулинг"). Count();
            //Получать количество книг определенного жанра в библиотеке
            var bookgenre = db.Books.Where(g=>g.Gener =="Фэнтези").Count();
            //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
            var trueBook = db.Books.All(t=>t.Author == "Л.Н Толстой" == (true));
            //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя
            var trueUser = db.Users.All(t => t.Name == "Зелёная лампа" ==(true));
            //Получать количество книг на руках у пользователя
            var joinedUserBook = db.Users.Join(db.Books, b => b.Id, u => u.Id, (b, u) => new { BookUser = u.Id });
            //Получение последней вышедшей книги
            var yearBook = db.Books.Max(b => b.Year == 2020);
            //Получение списка всех книг, отсортированного в алфавитном порядке по названию
            var listBook = db.Books.OrderBy(b => b.Name).ToList();
            //Получение списка всех книг, отсортированного в порядке убывания года их выхода
            var listBookYear = db.Books.OrderByDescending(b => b.Year).ToList();

        }

    }


}
