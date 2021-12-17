using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Library.WebApp.Models
{
    public class FilterVM
    {
        public List<SelectListItem> Persons { get; set; }
        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Types { get; set; }
        public string PreviousType { get; set; }
    }
}
