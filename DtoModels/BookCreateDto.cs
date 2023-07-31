using System.ComponentModel.DataAnnotations;

namespace ApiNet7.DtoModels
{
    public class BookCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public int Year { get; set; }
    }
}
