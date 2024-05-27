using DTO.FavoriteArticleDTO;
using Microsoft.AspNetCore.Mvc;

namespace Services.FavoriteArticleService;

public interface IFavoriteArticleService
{
    List<FavoriteArticleDTO> GetFavoriteArticles();
    List<FavoriteArticleDTO> GetUserFavoriteArticles(string id);
    Task<IActionResult> InsertFavoriteArticle(CreateFavoriteArticleDTO dto);
    void DeleteFavoriteArticle(int id);
}