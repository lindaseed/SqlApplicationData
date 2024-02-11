using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

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
        try
        {
            var result = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
            result ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });

            return new CategoryEntity { Id = result.Id, CategoryName = result.CategoryName };
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null!;
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

        try
        {
            var entity = _categoryRepository.GetOne(x => x.Id == categoryEntity.Id);
            if (entity != null)
            {
                entity.CategoryName = categoryEntity.CategoryName;

                var result = _categoryRepository.Update(entity);
                if (result != null)
                    return new CategoryEntity { Id = entity.Id, CategoryName = entity.CategoryName };
            }
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null!;
    }

    public bool DeleteCategory(Expression<Func<CategoryEntity, bool>> predicate)
    {
        try
        {
            var result = _categoryRepository.Delete(predicate);
            return result;
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return false;
    }
}
