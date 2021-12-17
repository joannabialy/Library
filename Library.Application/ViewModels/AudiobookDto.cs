﻿using Microsoft.AspNetCore.Http;
using System;

namespace Library.Application.ViewModels
{
    public class AudiobookDto
    {
        public int DigitalEntityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public int Length { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public DateTime PublicationDate { get; set; }
        public IFormFile ImageFormFile { get; set; }
        public string Tags { get; set; }
    }
}
