using Assesment3.Db.EntityConfigs;
using Assesment3.Dtos;
using Assesment3.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assesment3.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfig());
            builder.ApplyConfiguration(new AuthorConfig());
            builder.ApplyConfiguration(new BookCategoryConfig());


            Seeder.SeedDataIntoDatabase(builder);


            base.OnModelCreating(builder);


        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.DefaultTypeMapping<BookDto>();
        }
    }
}
