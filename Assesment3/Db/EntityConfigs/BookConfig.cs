using Assesment3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assesment3.Db.EntityConfigs;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(y => y.CategoryId);

        builder.HasOne(x => x.Author)
            .WithMany()
            .HasForeignKey(y => y.AuthorId);


        builder.ToTable(nameof(Book));
    }
}