using Data;
using DTO.FavoriteArticleDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FavoriteArticleRepository;

public class FavoriteArticleRepository(ApplicationContext context):IFavoriteArticleRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<FavoriteArticle> _favoritearticle = context.Set<FavoriteArticle>();

    public List<FavoriteArticleDTO> GetAll()
    {
        var favorites = _favoritearticle.ToList();
        List<FavoriteArticleDTO> favoriteDtos = new List<FavoriteArticleDTO>();
        foreach (var favorite in favorites)
        {
            favoriteDtos.Add(new FavoriteArticleDTO
            {
                FavoriteId = favorite.FavoriteId,
                ArticleId = favorite.ArticleId,
                UserId = favorite.UserId
            });
        }

        return favoriteDtos;
    }

    public List<FavoriteArticleDTO> GetUsers(int id)
    {
        var favoritesUser = _favoritearticle.Where(fu => fu.UserId == id);
        if (favoritesUser == null) return null;
        List<FavoriteArticleDTO> favoriteDtos = new List<FavoriteArticleDTO>();
        foreach (var favorite in favoritesUser)
        {
            favoriteDtos.Add(new FavoriteArticleDTO
            {
                FavoriteId = favorite.FavoriteId,
                ArticleId = favorite.ArticleId,
                UserId = favorite.UserId
            });
        }

        return favoriteDtos;
    }

    public void Insert(CreateFavoriteArticleDTO dto)
    {
        FavoriteArticle favoriteArticle = new FavoriteArticle
        {
            ArticleId = dto.ArticleId,
            UserId = dto.UserId,
        };
        _favoritearticle.Add(favoriteArticle);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var favoriteArticle = _favoritearticle.SingleOrDefault(fa => fa.FavoriteId == id);
        if (favoriteArticle == null) return;
        _favoritearticle.Remove(favoriteArticle);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}