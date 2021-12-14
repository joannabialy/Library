using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.WebApp.Components
{
    public class FilterByTypeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var types = new Dictionary<string, string> 
            { 
                { "Book", "Książka" }, 
                { "Audiobook", "Audiobook" }, 
                { "Magazine", "Magazyn" }, 
                { "Film", "Film" } };

            return View(types);
        }
    }
}
