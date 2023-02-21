namespace Assesment3.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int YearOfRelease { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorDateOfBirth { get; set; }
        public string Categories { get; set; }
    }
}
