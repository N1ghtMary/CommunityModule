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
    //TODO If toggle to false dont show subscriptions and likes
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
        //TODO add author include and his email
        
        
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
                    Email = subscription.Author.Email
                },
                UserId = subscription.UserId,
                User = new ShowUserInfoDTO()
                {
                    Email = subscription.User.Email
                }
            });
        }
        
        return subscriptionsDtos;
    }

    public List<SubscriptionAuthorDTO> GetUsers(string id)
    {
        var subscriptionsUser = _subscriptionAuthor.Where(su => su.UserId == id);
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
                    UserId = subscription.UserId
                });
            }
        }

        return subscriptionsDtos;
    }

    public List<SubscriptionAuthorDTO> GetAuthors(string id)
    {
        var subscriptionsAuthor = _subscriptionAuthor
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
                    UserId = subscription.UserId
                });
            }
        }

        return subscriptionsDtos;
    }

    public async Task<IActionResult> ToggleActive(ToggleSubscriptionAuthorDTO dto)
    {
        var user = await userManager.FindByIdAsync(dto.UserId);
        var author = await userManager.FindByIdAsync(dto.UserId);;
        if (user == null || author == null) return new BadRequestObjectResult("No such user or group");
        var subscriptions = _subscriptionAuthor.FirstOrDefault(s => 
            s.UserId == dto.UserId && s.AuthorId == dto.AuthorId);
        if (subscriptions == null)
        {
            SubscriptionAuthor subscriptionsNew = new SubscriptionAuthor
            {
                IsActive = true,
                AuthorId = dto.AuthorId,
                UserId = dto.UserId
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