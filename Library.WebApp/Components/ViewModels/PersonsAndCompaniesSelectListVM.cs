using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Components.ViewModels
{
    public class PersonsAndCompaniesSelectListVM
    {
        public List<SelectListItem> Persons { get; set; }
        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Types { get; set; }
    }
}
