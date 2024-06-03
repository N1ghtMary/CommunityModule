using Data;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository.UserRepository;

public class UserRepository(UserManager<User> userManager,
    ApplicationContext context):IUserRepository
{
    //private readonly ApplicationContext _context = context;
    private DbSet<User> _users = context.Set<User>();
    private DbSet<Article> _articles = context.Set<Article>();
    private DbSet<Comments> _comments = context.Set<Comments>();
    private DbSet<FavoriteArticle> _favoriteArticles = context.Set<FavoriteArticle>();
    private DbSet<Statistics> _statistics = context.Set<Statistics>();
    private DbSet<SubscriptionAuthor> _subscriptionAuthors = context.Set<SubscriptionAuthor>();
    
    public async Task<List<User>> GetAll()
    {
        return await userManager.Users.ToListAsync();
    }
    public async Task<UserDTO> Get(string id)
    {
        //var user = _users.SingleOrDefault(u => u.Id == id);
        var user = await userManager.FindByIdAsync(id);
        if (user == null) return null;
        
        return new UserDTO
        {
            UserId = user.Id,
            UserFullName = user.UserName,
            BirthDate = user.BirthDate,
            City = user.City,
            Email = user.Email,
            Login = user.Login,
            //Password = dto.Password,
            PhoneNumber = user.PhoneNumber
        };
       //var user =await userManager.FindByIdAsync(id);
       
       //return user;
    }

   /* public List<UserDTO> GetAll()
    {
        var users = _users.ToList();
        List<UserDTO> userDtos = new List<UserDTO>();
        foreach (var user in users)
        {
            userDtos.Add(new UserDTO
            {
                UserId = user.Id,
                UserFullName = user.UserName,
                BirthDate = user.BirthDate,
                City=user.City,
                Email = user.Email,
                Login = user.Login,
                //Password = user.Password,
                PhoneNumber = user.PhoneNumber
            });   
        }

        return userDtos;
    }*/

    public async Task<IdentityResult> Insert(CreateUserDTO dto)
    {
        User user = new User
        {
            UserName = dto.UserName,
            BirthDate = dto.BirthDate,
            City = dto.City,
            Email = dto.Email,
            Login = dto.Login,
            //Password = dto.Password,
            PhoneNumber = dto.PhoneNumber
        };
        
        var result = await userManager.CreateAsync(user, dto.Password); //хэширует пароль и вбд хранится хэш пароля
        return result;
       // _users.Add(user);
        //context.SaveChanges();
    }

    public async Task<IActionResult> Update(UpdateUserDTO dto)
    {
        var user = await userManager.FindByIdAsync(dto.UserId);
        if (user == null) return new NotFoundResult();
        user.UserName = dto.UserFullName;
        user.BirthDate = dto.BirthDate;
        user.City = dto.City;
        user.Email = dto.Email;
        user.Login = dto.Login;
        user.PhoneNumber = dto.PhoneNumber;
        await userManager.UpdateAsync(user);
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public async Task<IActionResult> ChangePassword(ChangePasswordUserDTO dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null) return new NotFoundResult();
        if(dto.NewPassword==dto.OldPassword) return new BadRequestObjectResult("New password must be different");
        var result = await userManager
            .ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        if (result.Succeeded) return new OkResult();
        else return new BadRequestObjectResult("Something went wrong");
    }
    
    public void Delete(string id)
    {
        var user =_users.SingleOrDefault(u => u.Id == id);
        if (user == null) return;
        var commentsList = _comments.Where(c => c.UserId == user.Id);
        _comments.RemoveRange(commentsList);
        
        var articlesList = _articles.Where(a => a.UserId == user.Id)
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
        var favoriteArticlesUser=_favoriteArticles.Where(f => f.UserId == user.Id);
        _favoriteArticles.RemoveRange(favoriteArticlesUser);
        
        var statisticsUser = _statistics.Where(s => s.UserId == user.Id);
        _statistics.RemoveRange(statisticsUser);

        var subscriptionAuthor = _subscriptionAuthors
            .Where(sa => sa.UserId == user.Id || sa.AuthorId == user.Id);
        _subscriptionAuthors.RemoveRange(subscriptionAuthor);
        
        _users.Remove(user);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}