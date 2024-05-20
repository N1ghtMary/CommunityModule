using Data;
using DTO.CategoryDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.CategoryRepository;

public class CategoryRepository(ApplicationContext context):ICategoryRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Category> _categories = context.Set<Category>();
    private DbSet<Group> _groups = context.Set<Group>();
    private DbSet<Article> _articles = context.Set<Article>();
    private DbSet<Comments> _comments = context.Set<Comments>();
    private DbSet<FavoriteArticle> _favoriteArticles = context.Set<FavoriteArticle>();
    private DbSet<Statistics> _statistics = context.Set<Statistics>();
    
    public CategoryDTO Get(int Id)
    {
        var category = _categories.SingleOrDefault(c => c.CategoryId == Id);
        if (category == null) return null;
        return new CategoryDTO
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        };
    }

    public List<CategoryDTO> GetAll()
    {
        var categories = _categories.ToList();
        List<CategoryDTO> categoryDtos = new List<CategoryDTO>();
        foreach (var category in categories)
        {
         categoryDtos.Add(new CategoryDTO
         {
             CategoryId = category.CategoryId,
             CategoryName = category.CategoryName
         });   
        }

        return categoryDtos;
    }

    public void Insert(CreateCategoryDTO dto)
    {
        Category category = new Category
        {
            CategoryName = dto.CategoryName
        };
        _categories.Add(category);
        context.SaveChanges();
    }

    public void Update(UpdateCategoryDTO dto)
    {
        var category = _categories.SingleOrDefault(c => c.CategoryId == dto.CategoryId);
        if (category == null) return;
        category.CategoryName = dto.CategoryName;
        _categories.Update(category);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        var category =_categories.SingleOrDefault(c => c.CategoryId == Id);
        if (category == null) return;
        var groupsList = _groups.Where(g => g.CategoryId == category.CategoryId)
            .ToList();
        foreach (var group in groupsList)
        {
            var articles = _articles.
                Where(a => a.GroupId == group.GroupId);
            foreach (var article in articles)
            {
                var comments = _comments
                    .Where(c => c.ArticleId == article.ArticleId);
                _comments.RemoveRange(comments);
                var favoritesArticle = _favoriteArticles.Where(f => f.ArticleId == article.ArticleId);
                _favoriteArticles.RemoveRange(favoritesArticle);

                var statisticsArticle = _statistics.Where(s => s.ArticleId == article.ArticleId);
                _statistics.RemoveRange(statisticsArticle);
            }
            _articles.RemoveRange(articles);
        }
        _groups.RemoveRange(groupsList);
        _categories.Remove(category);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}