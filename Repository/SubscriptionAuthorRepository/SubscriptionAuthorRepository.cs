using Data;
using DTO.SubscriptionAuthorDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository.SubscriptionAuthorRepository;

public class SubscriptionAuthorRepository(UserManager<User> userManager,
    ApplicationContext context):ISubscriptionAuthorRepository
{
    //TODO Check author must write articles. If user has no articles he can't be author
    private readonly ApplicationContext _context = context;
    private DbSet<SubscriptionAuthor> _subscriptionAuthor = context.Set<SubscriptionAuthor>();
    //private DbSet<User> _users = context.Set<User>();

    public List<SubscriptionAuthorDTO> GetAll()
    {
        var subscriptions = _subscriptionAuthor
            .Include(sa=>sa.Author)
            .Include(su=>su.User)
            .ToList();
        List<SubscriptionAuthorDTO> subscriptionsDtos = new List<SubscriptionAuthorDTO>();
        
        foreach (var subscription in subscriptions)
        {
            //foreach (var user in subscription.User)
            //{
                
            //}
            subscriptionsDtos.Add(new SubscriptionAuthorDTO
            {
                SubscriptionId = subscription.SubscriptionId,
                IsActive = subscription.IsActive,
                AuthorId = subscription.AuthorId,
                Author = new ShowUserInfoDTO()
                {
                    Login = subscription.Author.Login
                },
                UserId = subscription.UserId,
                User = new ShowUserInfoDTO()
                {
                    Login = subscription.User.Login
                }
            });
        }
        
        return subscriptionsDtos;
    }

    public List<SubscriptionAuthorDTO> GetUsers(string id)
    {
        var subscriptionsUser = _subscriptionAuthor
            .Include(sa=>sa.Author)
            .Include(su=>su.User)
            .Where(su => su.UserId == id);
        if (subscriptionsUser == null) return null;
        List<SubscriptionAuthorDTO> subscriptionsDtos = new List<SubscriptionAuthorDTO>();
        foreach (var subscription in subscriptionsUser)
        {
            if (subscription.IsActive)
            {
                subscriptionsDtos.Add(new SubscriptionAuthorDTO
                {
                    SubscriptionId = subscription.SubscriptionId,
                    IsActive = subscription.IsActive,
                    AuthorId = subscription.AuthorId,
                    Author = new ShowUserInfoDTO()
                    {
                        Login = subscription.Author.Login
                    },
                    UserId = subscription.UserId,
                    User = new ShowUserInfoDTO()
                    {
                        Login = subscription.User.Login
                    }
                });
            }
        }

        return subscriptionsDtos;
    }

    public List<SubscriptionAuthorDTO> GetAuthors(string id)
    {
        var subscriptionsAuthor = _subscriptionAuthor
            .Include(sa=>sa.Author)
            .Include(su=>su.User)
            .Where(sa => sa.AuthorId == id);
        if (subscriptionsAuthor == null) return null;
        List<SubscriptionAuthorDTO> subscriptionsDtos = new List<SubscriptionAuthorDTO>();
        foreach (var subscription in subscriptionsAuthor)
        {
            if(subscription.IsActive)
            {
                subscriptionsDtos.Add(new SubscriptionAuthorDTO
                {
                    SubscriptionId = subscription.SubscriptionId,
                    IsActive = subscription.IsActive,
                    AuthorId = subscription.AuthorId,
                    Author = new ShowUserInfoDTO()
                    {
                        Login = subscription.Author.Email
                    },
                    UserId = subscription.UserId,
                    User = new ShowUserInfoDTO()
                    {
                        Login = subscription.User.Email
                    }
                });
            }
        }

        return subscriptionsDtos;
    }
    
    public async Task<IActionResult> ToggleActive(ToggleSubscriptionAuthorDTO dto)
    {
        var user = await userManager.FindByEmailAsync(dto.User.Email);
        var author = await userManager.FindByIdAsync(dto.Author.Email);;
        if (user == null || author == null) return new BadRequestObjectResult("No such user or group");
        var subscriptions = _subscriptionAuthor.FirstOrDefault(s => 
            s.User.Email == dto.User.Email && s.Author.Email == dto.Author.Email);
        if (user.Id == author.Id)
            return new BadRequestObjectResult("You can't subscribe yourself but u r still perfect");
        if (subscriptions == null)
        {
            SubscriptionAuthor subscriptionsNew = new SubscriptionAuthor
            {
                IsActive = true,
                AuthorId = author.Id,
                UserId = user.Id
            };
            _subscriptionAuthor.Add(subscriptionsNew);
        }
        else
        {
            subscriptions.IsActive = subscriptions.IsActive == true ? false : true;
            _subscriptionAuthor.Update(subscriptions);
        }
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}