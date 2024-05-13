using DTO.FavoriteArticleDTO;

namespace Services.FavoriteArticleService;

public interface IFavoriteArticleService
{
    List<FavoriteArticleDTO> GetFavoriteArticles();
    List<FavoriteArticleDTO> GetUserFavoriteArticles(int id);
    void InsertFavoriteArticle(CreateFavoriteArticleDTO dto);
    void DeleteFavoriteArticle(int id);
}