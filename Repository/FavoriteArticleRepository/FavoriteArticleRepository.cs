using Data;
using DTO.FavoriteArticleDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository.FavoriteArticleRepository;

public class FavoriteArticleRepository(UserManager<User> userManager,
    ApplicationContext context):IFavoriteArticleRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<FavoriteArticle> _favoritearticle = context.Set<FavoriteArticle>();
    //private DbSet<User> _users = context.Set<User>();
    private DbSet<Article> _articles = context.Set<Article>();

    public List<FavoriteArticleDTO> GetAll()
    {
        var favorites = _favoritearticle
            .Include(fa=>fa.User)
            .ToList();
        List<FavoriteArticleDTO> favoriteDtos = new List<FavoriteArticleDTO>();
        foreach (var favorite in favorites)
        {
            favoriteDtos.Add(new FavoriteArticleDTO
            {
                FavoriteId = favorite.FavoriteId,
                ArticleId = favorite.ArticleId,
                User = new ShowUserInfoDTO()
                {
                    Email = favorite.User.Email
                }
            });
        }

        return favoriteDtos;
    }

    public List<FavoriteArticleDTO> GetUsers(string id)
    {
        var favoritesUser = _favoritearticle
            .Include(fa=>fa.User)
            .Where(fu => fu.UserId == id);
        if (favoritesUser == null) return null;
        List<FavoriteArticleDTO> favoriteDtos = new List<FavoriteArticleDTO>();
        foreach (var favorite in favoritesUser)
        {
            favoriteDtos.Add(new FavoriteArticleDTO
            {
                FavoriteId = favorite.FavoriteId,
                ArticleId = favorite.ArticleId,
                User = new ShowUserInfoDTO()
                {
                    Email = favorite.User.Email
                }
            });
        }

        return favoriteDtos;
    }

    public async Task<IActionResult> Insert(CreateFavoriteArticleDTO dto)
    {
        var author = await userManager.FindByEmailAsync(dto.User.Email);
        var article = _articles.Where(a => a.ArticleId == dto.ArticleId);
        if (author == null || article == null) return new BadRequestObjectResult("No such user or article");
        var favorites = _favoritearticle.FirstOrDefault(s => 
            s.User.Email == dto.User.Email && s.ArticleId == dto.ArticleId);
        if (favorites == null)
        {
            FavoriteArticle favoriteArticle = new FavoriteArticle
            {
                ArticleId = dto.ArticleId,
                UserId = author.Id,
            };
            _favoritearticle.Add(favoriteArticle);
        }
        else _favoritearticle.Remove(favorites);

        await context.SaveChangesAsync();
        return new OkResult();
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