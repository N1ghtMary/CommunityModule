using DTO.ArticleDTO;

namespace Repository.ArticleRepository;

public interface IArticleRepository
{
    ArticleDTO Get(int Id);
    List<ArticleDTO> GetAll();
    void Insert(CreateArticleDTO dto);
    void Update(UpdateArticleDTO dto);
    void Delete(int Id);
    void SaveChanges();
}