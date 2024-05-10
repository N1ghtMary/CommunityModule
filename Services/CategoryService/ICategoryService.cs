using DTO.CategoryDTO;

namespace Services.CategoryService;

public interface ICategoryService
{
    CategoryDTO GetCategory(int Id);
    List<CategoryDTO> GetCategories();
    void InsertCategory(CreateCategoryDTO dto);
    void UpdateCategory(UpdateCategoryDTO dto);
    void DeleteCategory(int Id);
}