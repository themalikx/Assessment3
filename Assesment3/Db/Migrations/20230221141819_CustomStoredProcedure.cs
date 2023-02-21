using Microsoft.EntityFrameworkCore.Migrations;



namespace Assesment3.Db.Migrations
{

    public partial class CustomStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @"
        create Function [dbo].[GetCategoriesByChildCategoryId] (@catId int) returns nvarchar(max)
        as
        Begin
          declare @rn_result nvarchar(max);
          WITH tree  AS  (
          SELECT Id,  ParentCategoryId, Name, 1 as level2
          FROM BookCategory
          WHERE Id = @catId

          UNION ALL

          SELECT child.Id, child.ParentCategoryId, child.name, parent.level2 + 1
          FROM BookCategory as child
            JOIN tree parent on parent.ParentCategoryId = child.Id
        )
          select @rn_result =( STRING_AGG(Name, ', ')   within group ( order by tree.level2 desc  ) )  from tree
          return @rn_result;
        End
         Go

        CREATE PROCEDURE [dbo].[GetBookById]
                        @bookId int AS
        BEGIN
	        SET NOCOUNT ON;
	        select Book.Id, Title, Subtitle, YearOfRelease, dbo.GetCategoriesByChildCategoryId(CategoryId) as Categories, Author.Name as AuthorName, Author.DateOfBirth as AuthorDateOfBirth from Book  
	        inner join Author on Book.AuthorId = Author.Id
	        where Book.Id = @bookId 
        END
        Go

        CREATE PROCEDURE [dbo].[GetAllBooks]
            AS    
        BEGIN
	        SET NOCOUNT ON;
	        select Book.Id, Title, Subtitle, YearOfRelease, dbo.GetCategoriesByChildCategoryId(CategoryId) as Categories, Author.Name as AuthorName, Author.DateOfBirth as AuthorDateOfBirth from Book  
	        inner join Author on Book.AuthorId = Author.Id
        END
        Go

";
            migrationBuilder.Sql(query);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var query = @"drop function [dbo].[GetCategoriesByChildCategoryId];
                          drop procedure [dbo].[GetBookById];
                          drop procedure [dbo].[GetAllBooks] ;";
            migrationBuilder.Sql(query);
        }
    }
}
