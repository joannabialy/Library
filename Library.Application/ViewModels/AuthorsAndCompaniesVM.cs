using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Application.ViewModels
{
    public class PersonsAndCompaniesVM
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
