namespace DTO.FavoriteArticleDTO;

public class CreateFavoriteArticleDTO
{
    public int FavoriteId { get; set; }
    public int ArticleId { get; set; }
    public int UserId { get; set; }
}