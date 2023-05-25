using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractices
{
    public class UserRepository
    {
        public static void UserMenu()
        {
            var user = new User();
            Console.WriteLine("В меню User Вам доступны следующие действия: ");
            Console.WriteLine("1.выбор объекта из БД по его идентификатору");
            Console.WriteLine("2.выбор всех объектов БД");
            Console.WriteLine("3.добавить пользователя в БД");
            Console.WriteLine("4. удаление пользователя из БД");
            Console.WriteLine("5.обновление имени пользователя (по Id)");
            Console.WriteLine(Command.stop + ": прекращение работы");
            string command;
            do
            {
                Console.WriteLine(" Ввидите команду");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        SelectUser();
                        break;
                    case "2":
                        SelectAllUsers();
                        break;
                    case "3":
                        AddUser();

                        break;
                    case "4":
                        RemoveUser();
                        break;
                    case "5":
                        UpdateUser();
                        break;
                        
                }
                Console.WriteLine();

            }
            while (command != nameof(Command.stop));
            Console.WriteLine("Работа прекращена");


        }
        public static void SelectUser()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите Id пользователя");
            var Id = Int32.Parse(Console.ReadLine());
            var user = db.Users.Where(c => c.Id == Id).FirstOrDefault();
            Console.WriteLine(user.Name);
        }
        public static void SelectAllUsers()
        {
            var db = new AppContext();
            var allUsers = db.Users.ToList();
            foreach (var user in allUsers)
            {
                Console.WriteLine($"{user.Name} {user.Id}");
                
            }
        }
        public static void AddUser()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите имя пользователя");
            string name = Console.ReadLine();
            Console.WriteLine("Ввидите Email");
            string email = Console.ReadLine();

            User user = new User {  Name = name, Email = email };
            db.Users.Add(user);
            db.SaveChanges();

        }
        public static void RemoveUser()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите Id пользователя для удаления");
            var Id = Int32.Parse(Console.ReadLine());

            User user = db.Users.Where(c => c.Id == Id).FirstOrDefault();


            db.Users.Remove(user);
            db.SaveChanges();
        }
        public static void UpdateUser()
        {
            var db = new AppContext();
            Console.WriteLine("Ввидите Id пользователя");
            var Id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ввидте новое имя пользователя");
            string newName = Console.ReadLine();

            db.Users.Where(c => c.Id == Id).First().Name = newName;
            db.SaveChanges();
        }
        public enum Command
        {
            stop
        }
    }
}
