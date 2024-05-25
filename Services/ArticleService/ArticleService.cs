using DTO.ArticleDTO;
using Microsoft.AspNetCore.Mvc;
using Repository.ArticleRepository;

namespace Services.ArticleService;

public class ArticleService(IArticleRepository articleRepository) : IArticleService
{
    private IArticleRepository _articleRepository = articleRepository;

    public ArticleDTO GetArticle(int id)
    {
        return _articleRepository.Get(id);
    }

    public List<ArticleDTO> GetArticles()
    {
        return _articleRepository.GetAll();
    }

    public async Task<IActionResult> InsertArticle(CreateArticleDTO dto)
    {
        return await _articleRepository.Insert(dto);
    }

    public async Task<IActionResult> UpdateArticle(UpdateArticleDTO dto)
    {
        return await _articleRepository.Update(dto);
    }

    public async Task<IActionResult> IncreaseViewsArticle(int id)
    {
       return await _articleRepository.Views(id);
    }
    public async Task<IActionResult> DeleteArticle(int id)
    {
        return await _articleRepository.Delete(id);
    }
}