using Microsoft.AspNetCore.Http;
using System;

namespace Library.Application.ViewModels
{
    public class FilmDto
    {
        public int DigitalEntityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public int Length { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
        public DateTime PremiereDate { get; set; }
        public IFormFile ImageFormFile { get; set; }
        public string Tags { get; set; }
    }
}
