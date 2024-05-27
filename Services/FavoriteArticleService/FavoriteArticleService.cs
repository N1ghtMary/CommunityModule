using DTO.FavoriteArticleDTO;
using Microsoft.AspNetCore.Mvc;
using Repository.FavoriteArticleRepository;

namespace Services.FavoriteArticleService;

public class FavoriteArticleService(IFavoriteArticleRepository favoriteArticleRepository):IFavoriteArticleService
{
    private IFavoriteArticleRepository _favoriteArticleRepository = favoriteArticleRepository;

    public List<FavoriteArticleDTO> GetFavoriteArticles()
    {
        return _favoriteArticleRepository.GetAll();
    }
    
    public List<FavoriteArticleDTO> GetUserFavoriteArticles(string id)
    {
        return _favoriteArticleRepository.GetUsers(id);
    }

    public async Task<IActionResult> InsertFavoriteArticle(CreateFavoriteArticleDTO dto)
    {
        return await _favoriteArticleRepository.Insert(dto);
    }

    public void DeleteFavoriteArticle(int id)
    {
        _favoriteArticleRepository.Delete(id);
    }
}