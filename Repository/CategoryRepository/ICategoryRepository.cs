using DTO.CategoryDTO;

namespace Repository.CategoryRepository;

public interface ICategoryRepository
{
    CategoryDTO Get(int Id);
    List<CategoryDTO> GetAll();
    void Insert(CreateCategoryDTO dto);
    void Update(UpdateCategoryDTO dto);
    void Delete(int Id);
    void SaveChanges();
}