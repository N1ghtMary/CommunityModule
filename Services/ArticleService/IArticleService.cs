using DTO.ArticleDTO;

namespace Services.ArticleService;

public interface IArticleService
{
    ArticleDTO GetArticle(int Id);
    List<ArticleDTO> GetArticles();
    void InsertArticle(CreateArticleDTO dto);
    void UpdateArticle(UpdateArticleDTO dto);
    void DeleteArticle(int Id);
}