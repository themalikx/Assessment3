namespace Assesment3.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime YearOfRelease { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public virtual Author Author { get; set; }
        public virtual BookCategory Category { get; set; }
    }
}
