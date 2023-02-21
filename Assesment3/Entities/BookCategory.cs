namespace Assesment3.Entities;

public class BookCategory : BaseEntity
{
    public int ParentCategoryId { get; set; }
    public string Name { get; set; }
}