namespace DTO.ArticleDTO;

public class ArticleDTO
{
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string ArticleText { get; set; }
    public DateTime ArticlePublicationDate { get; set; }
    public int UserId { get; set; }
    public int GroupId { get; set; }
    public int Views { get; set; }
}