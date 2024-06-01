using Data;
using DTO.ArticleDTO;
using DTO.CommentDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository.CommentRepository;

public class CommentRepository(UserManager<User> userManager,ApplicationContext context):ICommentRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Comments> _comments = context.Set<Comments>();

    public CommentDTO Get(int id)
    {
        var comment = _comments
            .Include(c=>c.User)
            .Include(a=>a.Article)
            .SingleOrDefault(c => c.CommentId == id);
        if (comment == null) return null;
        return new CommentDTO
        {
            CommentId = comment.CommentId,
            CommentText = comment.CommentText,
            CommentPublicationDate = comment.CommentPublicationDate,
            User = new ShowUserInfoDTO()
            {
                Login = comment.User.Login
            },
            Article = new ShowArticleInfoDTO()
            {
                Title = comment.Article.Title,
                Author = comment.Article.Author.Login
            }
        };
    }

    public List<CommentDTO> GetAll()
    {
        var comments = _comments
            .Include(c=>c.User)
            .ToList();
        List<CommentDTO> commentDtos = new List<CommentDTO>();
        foreach (var comment in comments)
        {
            commentDtos.Add(new CommentDTO
            {
                CommentId = comment.CommentId,
                CommentText = comment.CommentText,
                CommentPublicationDate = comment.CommentPublicationDate,
                User = new ShowUserInfoDTO()
                {
                    Login = comment.User.Login
                },
                Article = new ShowArticleInfoDTO()
                {
                    Title = comment.Article.Title,
                    Author = comment.Article.Author.Login
                }
            });   
        }

        return commentDtos;
    }

    public async Task<IActionResult> Insert(CreateCommentDTO dto)
    {
        var author = await userManager.FindByEmailAsync(dto.User.Email);
        if(author== null) return new BadRequestObjectResult("No such user");
        Comments comment = new Comments
        {
            CommentId = dto.CommentId,
            CommentText = dto.CommentText,
            CommentPublicationDate = dto.CommentPublicationDate,
            UserId=author.Id,
            ArticleId = dto.ArticleId
        };
        _comments.Add(comment);
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public async Task<IActionResult> Update(UpdateCommentDTO dto)
    {
        var author = await userManager.FindByEmailAsync(dto.User.Email);
        var comment = _comments
            .SingleOrDefault(c => c.CommentId == dto.CommentId);
        if (comment == null || author == null) return new BadRequestObjectResult("No such user or comment");
        comment.CommentId = dto.CommentId;
        comment.CommentText = dto.CommentText;
        comment.CommentPublicationDate = dto.CommentPublicationDate;
        comment.UserId = author.Id;
        comment.ArticleId = dto.ArticleId;
        _comments.Update(comment);
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public void Delete(int id)
    {
        var comment =_comments.SingleOrDefault(c => c.CommentId == id);
        if (comment == null) return;
        _comments.Remove(comment);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}