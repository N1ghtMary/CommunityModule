using Data;
using DTO.SubscriptionAuthorDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.SubscriptionAuthorRepository;

public class SubscriptionAuthorRepository(ApplicationContext context):ISubscriptionAuthorRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<SubscriptionAuthor> _subscriptionAuthor = context.Set<SubscriptionAuthor>();
    private DbSet<User> _users = context.Set<User>();

    public List<SubscriptionAuthorDTO> GetAll()
    {
        var subscriptions = _subscriptionAuthor.ToList();
        List<SubscriptionAuthorDTO> subscriptionsDtos = new List<SubscriptionAuthorDTO>();
        foreach (var subscription in subscriptions)
        {
            subscriptionsDtos.Add(new SubscriptionAuthorDTO
            {
                SubscriptionId = subscription.SubscriptionId,
                IsActive = subscription.IsActive,
                AuthorId = subscription.AuthorId,
                UserId = subscription.UserId
            });
        }

        return subscriptionsDtos;
    }

    public List<SubscriptionAuthorDTO> GetUsers(int id)
    {
        var subscriptionsUser = _subscriptionAuthor.Where(su => su.UserId == id);
        if (subscriptionsUser == null) return null;
        List<SubscriptionAuthorDTO> subscriptionsDtos = new List<SubscriptionAuthorDTO>();
        foreach (var subscription in subscriptionsUser)
        {
            subscriptionsDtos.Add(new SubscriptionAuthorDTO
            {
                SubscriptionId = subscription.SubscriptionId,
                IsActive = subscription.IsActive,
                AuthorId = subscription.AuthorId,
                UserId = subscription.UserId
            });
        }

        return subscriptionsDtos;
    }

    public List<SubscriptionAuthorDTO> GetAuthors(int id)
    {
        var subscriptionsAuthor = _subscriptionAuthor.Where(sa => sa.AuthorId == id);
        if (subscriptionsAuthor == null) return null;
        List<SubscriptionAuthorDTO> subscriptionsDtos = new List<SubscriptionAuthorDTO>();
        foreach (var subscription in subscriptionsAuthor)
        {
            subscriptionsDtos.Add(new SubscriptionAuthorDTO
            {
                SubscriptionId = subscription.SubscriptionId,
                IsActive = subscription.IsActive,
                AuthorId = subscription.AuthorId,
                UserId = subscription.UserId
            });
        }

        return subscriptionsDtos;
    }

    public void ToggleActive(ToggleSubscriptionAuthorDTO dto)
    {
        var user = _users.Where(u => u.UserId == dto.UserId);
        var author = _users.Where(a => a.UserId == dto.AuthorId);
        if (user == null || author == null) return;
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
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}