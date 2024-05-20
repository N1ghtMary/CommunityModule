//using System.Text.RegularExpressions;
using DTO.GroupDTO;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Repository.GroupRepository;

public class GroupRepository(ApplicationContext context):IGroupRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Group> _groups = context.Set<Group>();
    private DbSet<Article> _articles = context.Set<Article>();
    private DbSet<Comments> _comments = context.Set<Comments>();
    private DbSet<FavoriteArticle> _favoriteArticles = context.Set<FavoriteArticle>();
    private DbSet<Statistics> _statistics = context.Set<Statistics>();

    public GroupDTO Get(int Id)
    {
        var group = _groups.SingleOrDefault(g => g.GroupId == Id);
        if (group == null) return null;
        return new GroupDTO
        {
            GroupId = group.GroupId,
            GroupName = group.GroupName,
            CategoryId = group.CategoryId
        };
    }

    public List<GroupDTO> GetAll()
    {
        var groups = _groups.ToList();
        List<GroupDTO> groupDtos = new List<GroupDTO>();
        foreach (var group in groups)
        {
            groupDtos.Add(new GroupDTO
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                CategoryId = group.CategoryId
            });   
        }

        return groupDtos;
    }

    public void Insert(CreateGroupDTO dto)
    {
        Group group = new Group
        {
            GroupName = dto.GroupName,
            CategoryId = dto.CategoryId
        };
        _groups.Add(group);
        context.SaveChanges();
    }

    public void Update(UpdateGroupDTO dto)
    {
        var group = _groups.SingleOrDefault(g => g.GroupId == dto.GroupId);
        if (group == null) return;
        group.GroupName = dto.GroupName;
        group.CategoryId = dto.CategoryId;
        _groups.Update(group);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        var group =_groups.SingleOrDefault(g => g.GroupId == Id);
        if (group == null) return;
        var articlesList = _articles.Where(al => al.GroupId == group.GroupId);
        foreach (var article in articlesList)
        {
            var commentsList = _comments.Where(cl => cl.ArticleId == article.ArticleId);
            _comments.RemoveRange(commentsList);
            var favoritesArticle = _favoriteArticles.Where(f => f.ArticleId == article.ArticleId);
            _favoriteArticles.RemoveRange(favoritesArticle);
            var statisticsArticle = _statistics.Where(s => s.ArticleId == article.ArticleId);
            _statistics.RemoveRange(statisticsArticle);
        }
        _articles.RemoveRange(articlesList);
        _groups.Remove(group);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}