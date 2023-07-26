namespace ApiNet7.DtoModels
{
    public class BookCreateDto
   {
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }
    }
}
