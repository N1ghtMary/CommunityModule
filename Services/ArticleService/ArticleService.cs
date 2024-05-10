using DTO.ArticleDTO;
using Repository.ArticleRepository;

namespace Services.ArticleService;

public class ArticleService(IArticleRepository articleRepository) : IArticleService
{
    private IArticleRepository _articleRepository = articleRepository;

    public ArticleDTO GetArticle(int Id)
    {
        return _articleRepository.Get(Id);
    }

    public List<ArticleDTO> GetArticles()
    {
        return _articleRepository.GetAll();
    }

    public void InsertArticle(CreateArticleDTO dto)
    {
        _articleRepository.Insert(dto);
    }

    public void UpdateArticle(UpdateArticleDTO dto)
    {
        _articleRepository.Update(dto);
    }

    public void DeleteArticle(int Id)
    {
        _articleRepository.Delete(Id);
    }
}