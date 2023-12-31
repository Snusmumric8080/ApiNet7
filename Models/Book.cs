﻿using System.ComponentModel.DataAnnotations;

namespace ApiNet7.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }
    }
}
