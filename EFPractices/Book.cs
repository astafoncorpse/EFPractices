using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractices
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public int Year { get; set; }

        public string Author { get; set; }
        public string Gener { get; set; }


        /// свойство называется навигационное
        public List<User> Users { get; set; } = new List<User>();
    }
}
