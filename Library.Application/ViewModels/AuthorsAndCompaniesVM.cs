using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class PersonsAndCompaniesVM
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
