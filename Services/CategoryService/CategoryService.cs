using DTO.CategoryDTO;
using Repository.CategoryRepository;

namespace Services.CategoryService;

public class CategoryService(ICategoryRepository categoryRepository ): ICategoryService
{
    private ICategoryRepository _categoryRepository = categoryRepository;

    public CategoryDTO GetCategory(int Id)
    {
        return _categoryRepository.Get(Id);
    }

    public List<CategoryDTO> GetCategories()
    {
        return _categoryRepository.GetAll();
    }
    
    public void InsertCategory(CreateCategoryDTO dto)
    {
        _categoryRepository.Insert(dto);
    }
    
    public void UpdateCategory(UpdateCategoryDTO dto)
    {
        _categoryRepository.Update(dto);
    }

    public void DeleteCategory(int Id)
    {
     _categoryRepository.Delete(Id);   
    }
}