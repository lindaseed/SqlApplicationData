using SqlApplication.Entities;
using SqlApplication.Repositories;

namespace SqlApplication.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public CategoryEntity CreateNewCategory(string categoryName)
    {
        var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
        categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName});

        return categoryEntity;
    }

    public CategoryEntity GetCategoryByName(string categoryName)
    {
        var categoryEntity = _categoryRepository.GetOne(x =>x.CategoryName == categoryName);
        return categoryEntity;
    }


    public CategoryEntity GetCategoryById(int id)
    {
        var categoryEntity = _categoryRepository.GetOne(x => x.Id == id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updateCategory = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updateCategory;
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.Delete(x => x.Id == id);
    }
}
