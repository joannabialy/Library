using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Audiobook> Audiobooks { get; set; }
        public List<Book> Books { get; set; }
        public List<Film> Films { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
