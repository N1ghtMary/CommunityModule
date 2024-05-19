using Data;
using DTO.UserDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.UserRepository;

public class UserRepository(ApplicationContext context):IUserRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<User> _users = context.Set<User>();
    private DbSet<Article> _articles = context.Set<Article>();
    private DbSet<Comments> _comments = context.Set<Comments>();
    private DbSet<FavoriteArticle> _favoriteArticles = context.Set<FavoriteArticle>();
    private DbSet<Statistics> _statistics = context.Set<Statistics>();
    private DbSet<SubscriptionAuthor> _subscriptionAuthors = context.Set<SubscriptionAuthor>();
    
    public UserDTO Get(int Id)
    {
        var user = _users.SingleOrDefault(u => u.UserId == Id);
        if (user == null) return null;
        return new UserDTO
        {
            UserId = user.UserId,
            UserFullName = user.UserFullName,
            BirthDate = user.BirthDate,
            City=user.City,
            Email = user.Email,
            Login = user.Login,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber
        };
    }

    public List<UserDTO> GetAll()
    {
        var users = _users.ToList();
        List<UserDTO> userDtos = new List<UserDTO>();
        foreach (var user in users)
        {
            userDtos.Add(new UserDTO
            {
                UserId = user.UserId,
                UserFullName = user.UserFullName,
                BirthDate = user.BirthDate,
                City=user.City,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber
            });   
        }

        return userDtos;
    }

    public void Insert(CreateUserDTO dto)
    {
        User user = new User
        {
            UserFullName = dto.UserFullName,
            BirthDate = dto.BirthDate,
            City = dto.City,
            Email = dto.Email,
            Login = dto.Login,
            Password = dto.Password,
            PhoneNumber = dto.PhoneNumber
        };
        _users.Add(user);
        context.SaveChanges();
    }

    public void Update(UpdateUserDTO dto)
    {
        var user = _users.SingleOrDefault(u => u.UserId == dto.UserId);
        if (user == null) return;
        user.UserFullName = dto.UserFullName;
        user.BirthDate = dto.BirthDate;
        user.City = dto.City;
        user.Email = dto.Email;
        user.Login = dto.Login;
        user.Password = dto.Password;
        user.PhoneNumber = dto.PhoneNumber;
        _users.Update(user);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        var user =_users.SingleOrDefault(u => u.UserId == Id);
        if (user == null) return;
        var commentsList = _comments.Where(c => c.UserId == user.UserId);
        _comments.RemoveRange(commentsList);
        
        var articlesList = _articles.Where(a => a.UserId == user.UserId)
            .ToList();
        foreach (var article in articlesList)
        {
            var comments = _comments
                .Where(c => c.ArticleId == article.ArticleId);
            _comments.RemoveRange(comments);

            var favoritesArticle = _favoriteArticles.Where(f => f.ArticleId == article.ArticleId);
            _favoriteArticles.RemoveRange(favoritesArticle);

            var statisticsArticle = _statistics.Where(s => s.ArticleId == article.ArticleId);
            _statistics.RemoveRange(statisticsArticle);
        }
        _articles.RemoveRange(articlesList);
        var favoriteArticlesUser=_favoriteArticles.Where(f => f.UserId == user.UserId);
        _favoriteArticles.RemoveRange(favoriteArticlesUser);
        
        var statisticsUser = _statistics.Where(s => s.UserId == user.UserId);
        _statistics.RemoveRange(statisticsUser);

        var subscriptionAuthor = _subscriptionAuthors
            .Where(sa => sa.UserId == user.UserId || sa.AuthorId == user.UserId);
        _subscriptionAuthors.RemoveRange(subscriptionAuthor);
        
        _users.Remove(user);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}