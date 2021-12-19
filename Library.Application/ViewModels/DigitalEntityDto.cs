using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.ViewModels
{
    public class DigitalEntityDto
    {
        public int DigitalEntityId { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Range(1, int.MaxValue, ErrorMessage = "Podaj wartość większą niż 0")]
        public int Length { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string PersonFirstName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string PersonLastName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public DateTime Date { get; set; }

        public IFormFile ImageFormFile { get; set; }
        public string Tags { get; set; }
        public string ISBN { get; set; }
        public string Type { get; set; }
    }
}
