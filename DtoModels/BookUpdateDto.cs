﻿using System.ComponentModel.DataAnnotations;

namespace ApiNet7.DtoModels
{
    public class BookUpdateDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }
    }
}
