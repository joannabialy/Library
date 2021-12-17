﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class DigitalEntityDto
    {
        public int DigitalEntityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public int Length { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public DateTime Date { get; set; }
        public IFormFile ImageFormFile { get; set; }
        public string Tags { get; set; }
        public string ISBN { get; set; }
        public string Type { get; set; }
    }
}