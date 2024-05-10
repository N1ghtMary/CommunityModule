using Data;
using DTO.CommentDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.CommentRepository;

public class CommentRepository(ApplicationContext context):ICommentRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Comments> _comments = context.Set<Comments>();

    public CommentDTO Get(int Id)
    {
        var comment = _comments.SingleOrDefault(c => c.CommentId == Id);
        if (comment == null) return null;
        return new CommentDTO
        {
            CommentId = comment.CommentId,
            CommentText = comment.CommentText,
            CommentPublicationDate = comment.CommentPublicationDate,
            UserId = comment.UserId,
            ArticleId = comment.ArticleId
        };
    }

    public List<CommentDTO> GetAll()
    {
        var comments = _comments.ToList();
        List<CommentDTO> commentDtos = new List<CommentDTO>();
        foreach (var comment in comments)
        {
            commentDtos.Add(new CommentDTO
            {
                CommentId = comment.CommentId,
                CommentText = comment.CommentText,
                CommentPublicationDate = comment.CommentPublicationDate,
                UserId = comment.UserId,
                ArticleId = comment.ArticleId
            });   
        }

        return commentDtos;
    }

    public void Insert(CreateCommentDTO dto)
    {
        Comments comment = new Comments
        {
            CommentId = dto.CommentId,
            CommentText = dto.CommentText,
            CommentPublicationDate = dto.CommentPublicationDate,
            UserId = dto.UserId,
            ArticleId = dto.ArticleId
        };
        _comments.Add(comment);
        context.SaveChanges();
    }

    public void Update(UpdateCommentDTO dto)
    {
        var comment = _comments
            .SingleOrDefault(c => c.CommentId == dto.CommentId);
        if (comment == null) return;
        comment.CommentId = dto.CommentId;
        comment.CommentText = dto.CommentText;
        comment.CommentPublicationDate = dto.CommentPublicationDate;
        comment.UserId = dto.UserId;
        comment.ArticleId = dto.ArticleId;
        _comments.Update(comment);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        var comment =_comments.SingleOrDefault(c => c.CommentId == Id);
        if (comment == null) return;
        _comments.Remove(comment);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}