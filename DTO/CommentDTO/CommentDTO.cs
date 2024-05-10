namespace DTO.CommentDTO;

public class CommentDTO
{
    public int CommentId { get; set; }
    public string CommentText { get; set; }
    public DateTime CommentPublicationDate { get; set; }
    public int UserId { get; set; }
    public int ArticleId { get; set; }
}