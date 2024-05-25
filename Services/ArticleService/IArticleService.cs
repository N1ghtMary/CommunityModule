using DTO.ArticleDTO;
using Microsoft.AspNetCore.Mvc;

namespace Services.ArticleService;

public interface IArticleService
{
    ArticleDTO GetArticle(int id);
    List<ArticleDTO> GetArticles();
    Task<IActionResult> InsertArticle(CreateArticleDTO dto);
    Task<IActionResult> UpdateArticle(UpdateArticleDTO dto);
    Task<IActionResult> IncreaseViewsArticle(int id);
    Task<IActionResult> DeleteArticle(int id);
}