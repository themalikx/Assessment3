using Assesment3.Entities;
using Assesment3.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assesment3.Services;

public interface ICategoryService
{
    Task<List<BookCategory>> GetCategoriesByParentCategoryId(int parentCategoryId);
}
public class CategoryService : ICategoryService
{
    private readonly IRepository<BookCategory> _categoryRepository;

    public CategoryService(IRepository<BookCategory> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<BookCategory>> GetCategoriesByParentCategoryId(int parentCategoryId)
    {
        return await _categoryRepository.Table
            .Where(x => x.ParentCategoryId == parentCategoryId)
            .ToListAsync();
    }
}